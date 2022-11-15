import  puppeteer  from "puppeteer";

describe("app.js",()=>{
    jest.setTimeout(25000)

    let browser;
    let page;

    beforeAll(async ()=>{
        browser= await puppeteer.launch({
            headless:true,
            slowMo: 0
        });
        page= await browser.newPage();
    });

    it("navigates to login page", async ()=>{
        await page.goto("http://localhost:3000");
        await page.waitForSelector("#header-component-loaded");
        await page.click("#user-login-button");
        await page.waitForSelector("#username-label")
        //Click on username input and type the username
        await page.click("#username");
        await page.type("#username", "testjson");
        //Click on password input and type the username
        await page.click("#password")
        await page.type("#password","testjson")

        await page.click("#login")

        await page.waitForSelector("#login-correct")
        const text = await page.$eval(
            "#login-correct",(e)=> e.textContent
        );
        expect(text).toContain("You are logged in!");
    });

    afterAll(()=>browser.close());
})