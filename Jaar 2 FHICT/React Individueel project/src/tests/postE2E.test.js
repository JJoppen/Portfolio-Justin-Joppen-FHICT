import  puppeteer  from "puppeteer";

describe("app.js",()=>{
    jest.setTimeout(5000)
    let browser;
    let page;

    beforeAll(async ()=>{
        browser= await puppeteer.launch({
            headless:true,
            slowMo: 2
        });
        page= await browser.newPage();
    });


    it("navigates to post page", async ()=>{
        await page.goto("http://localhost:3000");
        await page.waitForSelector("#header-component-loaded");
        await page.click("#post-button")
        await page.waitForSelector("#post-title")
        const text = await page.$eval("#post-title",(e)=>e.textContent);
        expect(text).toContain("look at this graph")
    });

    afterAll(()=>browser.close());
})