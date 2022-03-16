const { chromium } = require('playwright');
const { expect } = require('chai');

const path = 'http://127.0.0.1:5500/index.html';

let browser;
let page;

describe('Messenger app tests', function () {
    before(async () => {
        browser = await chromium.launch();
    });
    after(async () => {
        await browser.close();
    });
    beforeEach(async () => {
        page = await browser.newPage();
    });
    afterEach(async () => {
        await page.close();
    });

    it('initial load', async () => {
        await page.goto(path);

        const content = await page.textContent('#main');

        expect(content).to.contains('Name: ');
        expect(content).to.contains('Message: ');
    });

    it('"Refresh" button', async () => {
        await page.goto(path);

        const [request] = await Promise.all([
            page.waitForRequest(res => res.method() == 'GET'),
            page.click('text=Refresh')
        ]);

        const res = await request.response();
        const data = await res.json();
        const arrData = Object.values(data);

        expect(arrData[0].author).to.be.equal('Spami');
        expect(arrData[0].content).to.be.equal('Hello, are you there?');
        expect(arrData[1].author).to.be.equal('Garry');
        expect(arrData[1].content).to.be.equal('Yep, whats up :?');
    });

    it('"Submit" button', async () => {
        await page.goto(path);

        await page.click('text=Refresh');

        await page.fill('#author', 'Author-Test');
        await page.fill('#content', 'Content-Test');

        const [request] = await Promise.all([
            page.waitForRequest(res => res.method() == 'POST'),
            page.click('text=Send')
        ]);

        await page.click('text=Refresh');

        const data = JSON.parse(request.postData());
        expect(data.author).to.be.equal('Author-Test');
        expect(data.content).to.be.equal('Content-Test');
    });
});