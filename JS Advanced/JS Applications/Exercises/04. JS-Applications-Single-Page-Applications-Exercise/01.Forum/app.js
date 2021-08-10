import { topicCommentsPage } from './commentsPage.js';
import {topicsPage, topicsUrl} from './topicsPage.js';

document.querySelector('#home-link')
            .addEventListener('click', showTopicsPage);

topicsPage.setTopicChangeFunc(showCommentsPage);
topicsPage.loadTopics();

function showCommentsPage(e){
    let id = e.currentTarget.id;
    topicsPage.hidePage();
    topicCommentsPage.setId(id);
    topicCommentsPage.showPage();
}

function showTopicsPage(){
    topicCommentsPage.hidePage();
    topicsPage.loadTopics();
    topicsPage.showPage();
}
