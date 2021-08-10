import {createElement, addElement} from './helpers/funcs.js';
import {data, setUrl} from './dataServices/dataServise.js';

HTMLElement.prototype.add = addElement;
export const topicsUrl = 'http://localhost:3030/jsonstore/collections/myboard/posts';

export let topicsPage = {
    showPage,
    hidePage,
    loadTopics,
    setTopicChangeFunc
}

let topicPage = document.querySelector('main');

let newTopicForm = document.querySelector('.new-topic-border form');
newTopicForm.addEventListener('submit', addNewTopic);
let cancelButton = document.querySelector('.new-topic-border .cancel');
cancelButton.addEventListener('click', () => newTopicForm.reset());
let topicsContainer = document.querySelector('.topic-container');
let topicChangeFunc = undefined;

function setTopicChangeFunc(func){
    topicChangeFunc = func;
}

async function addNewTopic(e){
    e.preventDefault();

    let frmData = new FormData(newTopicForm);
    let userName = frmData.get('userName');
    let topicName = frmData.get('topicName');
    let postText = frmData.get('postText');
    if(!userName || !topicName || !postText) return;

    let posted = new Date();
    data.setUrl(topicsUrl);
    await data.add({userName, topicName, postText, posted});
    loadTopics();

}

function hidePage(){
    topicPage.classList.add('hidden');
}

function showPage(){
    topicPage.classList.remove('hidden');
}

async function loadTopics(){
    data.setUrl(topicsUrl);
    let topics = await data.get();
    topics = Object.values(topics);
    topicsContainer.innerHTML = '';
    topicsContainer.append(...topics.map(createTopicHTML));
} 


function createTopicHTML(topic){
    let div = createElement('div', ['class', 'topic-name-wrapper']);
    let div2 = div.add('div', ['class', 'topic-name']);
    let a = div2.add('a', 
                    ['href', 'javascript:void(0)'], 
                    ['id', topic._id],
                    ['class', 'normal'], 
                    createElement('h2', topic.topicName));
    a.addEventListener('click', topicChangeFunc);
    div2.add('div',
            ['class', 'columns'],
            createElement('div',
                        createElement('p', 'Date: ', 
                                    createElement('time', topic.posted)),
                        createElement('div', ['class', 'nick-name'],
                                    createElement('p', 'Username: ',
                                                createElement('span', topic.userName)))
                                    ));
    return div;
}
