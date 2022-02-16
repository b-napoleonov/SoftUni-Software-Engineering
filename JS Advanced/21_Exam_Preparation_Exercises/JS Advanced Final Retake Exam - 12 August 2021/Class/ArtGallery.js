//3 wrong tests in judge

class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            'picture': 200,
            'photo': 50,
            'item': 250
        }
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {
        articleModel = articleModel.toLowerCase();
        let currentArticle = this.listOfArticles.find(a => a.articleName === articleName);

        if (this.possibleArticles[articleModel] === undefined) {
            {
                throw new Error('This article model is not included in this gallery!');
            }
        }

        if (currentArticle != undefined && currentArticle.articleName == articleName && currentArticle.articleModel == articleModel) {
            currentArticle.quantity += Number(quantity);
        }
        else {
            this.listOfArticles.push({
                articleModel,
                articleName,
                quantity: Number(quantity)
            });
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        if (this.guests.find(x => x.guestName == guestName)) {
            throw new Error(`${guestName} has already been invited.`);
        }

        let p = 0;

        switch (personality) {
            case 'Vip':
                p = 500;
                break;

            case 'Middle':
                p = 250;
                break;
            default:
                p = 50;
                break;
        }

        let guest = {
            guestName,
            points: p,
            purchaseArticle: 0
        }

        this.guests.push(guest);
        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        let currentArticle = this.listOfArticles.find(a => a.articleName === articleName);
        let currentGuest = this.guests.find(g => g.guestName == guestName);

        if (this.listOfArticles.find(a => a.articleModel == articleModel || a.articleName == articleName) === undefined) {
            throw new Error('This article is not found.');
        }

        if (currentArticle.quantity <= 0) {
            return `The ${articleName} is not available.`;
        }

        if (currentGuest === undefined) {
            throw new Error(`This guest is not invited.`);
        }

        if (currentGuest.points < this.possibleArticles[articleModel]) {
            return `You need to more points to purchase the article.`;
        }
        else{
            currentGuest.points -= this.possibleArticles[articleModel];
            currentArticle.quantity -= 1;
            currentGuest.purchaseArticle += 1;
            return `${guestName} successfully purchased the article worth ${this.possibleArticles[articleModel]} points.`
        }
            
    }

    showGalleryInfo(criteria){
        let result = [];

        switch (criteria) {
            case 'article':
                result = [
                    'Articles information:',
                    this.listOfArticles.map(a => `${a.articleModel} - ${a.articleName} - ${a.quantity}`).join('\n')
                ];

                break;
        
            case 'guest':
                result = [
                    'Guests information:',
                    this.guests.map(g => `${g.guestName} - ${g.purchaseArticle}`).join('\n')
                ];

                break;
        }

        return result.join('\n');
    }
}

const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));