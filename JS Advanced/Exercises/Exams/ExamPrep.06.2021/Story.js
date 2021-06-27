class Story{
    #comments = [];
    #likes = [];
    constructor(title, creator){
        this.title = title;
        this.creator = creator;
    }

    get likes(){
        if(this.#likes.length == 0){
            return `${this.title} has 0 likes`;
        }else if(this.#likes.length == 1){
            return `${this.#likes[0]} likes this story!`;
        }else{
            return `${this.#likes[0]} and ${this.#likes.length - 1} others like this story!`;
        }
    }

    like (username){
        if(this.#likes.includes(username)){
            throw new Error('You can\'t like the same story twice!');
        }else if(username == this.creator){
            throw new Error('You can\'t like your own story!');
        }

        this.#likes.push(username);
        return `${username} liked ${this.title}!`;
    }
    dislike (username){
        if(!this.#likes.includes(username)){
            throw new Error('You can\'t dislike this story!');
        }

        this.#likes.splice(this.#likes.indexOf(username), 1);
        return `${username} disliked ${this.title}`;
    }
    comment (username, content, id){
        if(!id || this.#comments[id - 1] == undefined){
            let id = (this.#comments.length + 1);
            this.#comments.push({id, username, content, replies: []});
            return `${username} commented on ${this.title}`;
        }else{
            let replies = this.#comments[id - 1].replies;
            let replyId = Number(`${id}.${replies.length + 1}`);
            replies.push({id: replyId, username, content});
            return `You replied successfully`;
        }
    }
    toString(sortingType){
        let sortObject =  {
            'asc': (a, b) =>  (a.id) - (b.id),
            'desc': (a, b) =>  (b.id) - (a.id),
            'username': (a, b) =>  a.username.localeCompare(b.username)
        }

        let finalComments = Object.assign([], this.#comments)
                                .sort(sortObject[sortingType])
                                .map(c => {
                                        c.replies.sort(sortObject[sortingType]);
                                        return `\n-- ${c.id}. ${c.username}: ${c.content}` +
                                        c.replies.map(r => `\n--- ${r.id}. ${r.username}: ${r.content}`).join('');
                                    })
                                .join('');
        return `Title: ${this.title}
Creator: ${this.creator}
Likes: ${this.#likes.length}
Comments:${finalComments}`;
    }
}

let art = new Story("My Story", "Anny");
art.like("John")//, "John liked My Story!");
//assert.equal(art.likes, "John likes this story!");
//assert.throw(()=>art.dislike("Sally"), "You can't dislike this story!");
art.like("Ivan")//,"Ivan liked My Story!");
art.like("Steven")//, "Steven liked My Story!");
//assert.equal(art.likes, "John and 2 others like this story!");
console.log(art.comment("Anny", "Some Content"))//,"Anny commented on My Story");
console.log(art.comment("Ammy", "New Content", 1))//,"You replied successfully");
console.log(art.comment("Zane", "Reply", 2))//,"Zane commented on My Story");
console.log(art.comment("Jessy", "Nice :)"))//, "Jessy commented on My Story");
console.log(art.comment("SAmmy", "Reply@", 2))//, "You replied successfully");

console.log(art.toString('username'))
/*,`Title: My Story
Creator: Anny
Likes: 3
Comments:
-- 1. Anny: Some Content
--- 1.1. Ammy: New Content
-- 2. Zane: Reply
--- 2.1. SAmmy: Reply@
-- 3. Jessy: Nice :)`);  */

