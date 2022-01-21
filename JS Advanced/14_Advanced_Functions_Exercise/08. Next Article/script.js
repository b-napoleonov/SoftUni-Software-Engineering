function getArticleGenerator(articles) {
    let resultDiv = document.getElementById('content');

    return () => {
        if (articles.length != 0) {
            let article = document.createElement('article');
            article.textContent = articles.shift();
            resultDiv.appendChild(article);
        }
    }
}
