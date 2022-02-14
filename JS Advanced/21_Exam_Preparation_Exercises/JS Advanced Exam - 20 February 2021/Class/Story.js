//7 tests are wrong in judge
class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }

        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this story!`;
        }

        return `${this._likes[0]} and ${this.likes.length} others like this story!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error("You can't like the same story twice!");
        }

        if (username === this.creator) {
            throw new Error("You can't like your own story!");
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (this._likes.includes(username) === false) {
            throw new Error("You can't dislike this story!");
        }

        let userToRemove = this._likes.indexOf(username);
        this._likes.splice(userToRemove, 1);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let comment = this._comments.find(c => c.id === id);
        if (!id) {
            let id = this._comments.length + 1;
            this._comments.push({
                id,
                username,
                content,
                replies: []
            });

            return `${username} commented on ${this.title}`;
        }

        if (comment) {
            let lastId = comment.replies[comment.replies.length - 1];
            let id = 0;

            if (lastId === undefined) {
                id = comment.id + 0.1;
            }
            else {
                id = lastId.id + 0.1;
                id = Number(id.toFixed(1));
            }

            comment.replies.push({
                id,
                username,
                content
            });

            return `You replied successfully`;
        }
    }

    toString(sortingType) {
        let result = [
            `Title: ${this.title}`,
            `Creator: ${this.creator}`,
            `Likes: ${this._likes.length}`,
            `Comments:`
        ];

        let comments = [];

        switch (sortingType) {
            case 'asc':
                comments = this._comments.sort((a, b) => a.id - b.id);

                comments.forEach(c => {
                    result.push(`* ${c.id}. ${c.username}: ${c.content}`);

                    if (c.replies.length > 0) {
                        c.replies.forEach(r => {
                            result.push(`-- ${r.id}. ${r.username}: ${r.content}`);
                        });
                    }
                })
                break;

            case 'desc':
                comments = this._comments.sort((a, b) => b.id - a.id);

                comments.forEach(c => {
                    result.push(`* ${c.id}. ${c.username}: ${c.content}`);

                    if (c.replies.length > 0) {
                        c.replies.forEach(r => {
                            result.push(`-- ${r.id}. ${r.username}: ${r.content}`);
                        });
                    }
                })
                break;
            case 'username':
                comments = this._comments.sort((a, b) => a.username.localeCompare(b.username));

                comments.forEach(c => {
                    result.push(`* ${c.id}. ${c.username}: ${c.content}`);

                    if (c.replies.length > 0) {
                        c.replies.forEach(r => {
                            result.push(`-- ${r.id}. ${r.username}: ${r.content}`);
                        });
                    }
                });

                break;
        }

        return result.join('\n');
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));