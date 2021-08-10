import {data} from './dataServices/dataServise.js';
import { topicsUrl } from './topicsPage.js';
import {createElement, addElement} from './helpers/funcs.js';
HTMLElement.prototype.add = addElement;

export const commentsUrl = 'http://localhost:3030/jsonstore/collections/myboard/comments';

export let topicCommentsPage = {
    showPage,
    hidePage,
    setId,

}

let topicName = '';
let commentsPage = document.querySelector('#topic-comments');
let createCommentForm = commentsPage.querySelector('form');
createCommentForm.addEventListener('submit', createComment);

async function createComment(e){
    e.preventDefault();
    let frmData = new FormData(createCommentForm);
    let userName = frmData.get('userName');
    let postText = frmData.get('postText');
    if(!userName || !postText) return;
    let posted = new Date();
    data.setUrl(commentsUrl);
    await data.add({userName, postText, posted, topicName});
    loadComments();
    createCommentForm.reset();
}

function hidePage(){
    commentsPage.classList.add('hidden');
}

function showPage(){
    commentsPage.classList.remove('hidden');
}

async function setId(id){
    data.setUrl(topicsUrl);
    let topic = await data.get(id);
    topicName = topic.topicName;
    commentsPage.querySelector('h2').textContent = topicName;
    commentsPage.querySelector('.header span').textContent = topic.userName;
    commentsPage.querySelector('.header time').textContent = topic.posted;
    commentsPage.querySelector('.header .post-content').textContent = topic.postText;
    loadComments();
}

async function loadComments(){
    data.setUrl(commentsUrl);
    let comments = await data.get();
    comments = Object.values(comments).filter(x => x.topicName == topicName);
    let commentsContainer = commentsPage.querySelector('#user-comment');
    commentsContainer.innerHTML = '';
    let commentsHTML = comments.map(createCommentHtml);
    commentsContainer.append(...commentsHTML);
}

function createCommentHtml(comment){
    let divWrapper = createElement('div', ['class', 'topic-name-wrapper']);
    let divTopic = divWrapper.add('div', ['class', 'topic-name']);
    divTopic.add('p', 
        createElement('strong', comment.userName),
        document.createTextNode(' commented on '),
        createElement('time', comment.posted));
    divTopic.add('div', ['class', 'post-content'], createElement('p', comment.postText));

    return divWrapper;
}
