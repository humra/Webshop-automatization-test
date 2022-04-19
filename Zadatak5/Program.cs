using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Zadatak5
{
    internal class Program
    {
        //Default Timeout is quite long because sometimes the site is under heavy load
        private static int defaultTimeout = 10;
        private static ChromeDriver driver;
        private static Dictionary<string, string> userData = new Dictionary<string, string>();
        private static Dictionary<string, string> orderData = new Dictionary<string, string>();
        private static float maxPrice = 30f;
        private static float minPrice = 20f;

        static void Main(string[] args)
        {
            driver = CreateDriver();
            StartTest();
        }

        private static ChromeDriver CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();
            return new ChromeDriver(options);
        }

        private static void StartTest()
        {
            driver.Navigate().GoToUrl(Strings.url);
            driver.Manage().Window.Maximize();
            CreateNewUserData();
            Register();
            TestProducts();
            AfterShoppingTest();
            FinishShopping();
            DisplayUserData();
            DisplayOrderData();
        }

        private static void Register()
        {
            WaitForPageLoad();

            GetWaitForClickableElement(Strings.signInBtnXP).Click();
            GetWaitForClickableElement(Strings.emailInputXP).SendKeys(userData[Strings.userEmail]);
            GetWaitForClickableElement(Strings.createAccBtnXP).Click();

            if (userData[Strings.userGender].Equals(Strings.male))
            {
                GetWaitForClickableElement(Strings.maleRdXP).Click();
            }
            else
            {
                GetWaitForClickableElement(Strings.femaleRdXP).Click();
            }

            GetWaitForClickableElement(Strings.nameTxtXP).SendKeys(userData[Strings.userName]);
            GetWaitForClickableElement(Strings.lastNameTxtXP).SendKeys(userData[Strings.userLastName]);
            GetWaitForClickableElement(Strings.passwordTxtXP).SendKeys(userData[Strings.userPassword]);

            IWebElement day = GetWaitForClickableElement(Strings.dayDdlXP);
            IWebElement month = GetWaitForClickableElement(Strings.monthDdlXP);
            IWebElement year = GetWaitForClickableElement(Strings.yearDdlXP);
            SelectElement selectElement = new SelectElement(day);
            string[] DOBsplit = userData[Strings.userBirth].Split('/');
            selectElement.SelectByValue(DOBsplit[0].TrimStart('0'));
            selectElement = new SelectElement(month);
            selectElement.SelectByValue(DOBsplit[1].TrimStart('0'));
            selectElement = new SelectElement(year);
            selectElement.SelectByValue(DOBsplit[2]);

            GetWaitForClickableElement(Strings.addressXP).SendKeys(userData[Strings.userAddress]);
            GetWaitForClickableElement(Strings.cityXP).SendKeys(userData[Strings.userCity]);

            GetWaitForClickableElement(Strings.postalXP).SendKeys(userData[Strings.userZip]);
            GetWaitForClickableElement(Strings.phoneNumberXP).SendKeys(userData[Strings.userPhone]);
            GetWaitForClickableElement(Strings.addressAliasXP).Clear();
            GetWaitForClickableElement(Strings.addressAliasXP).SendKeys(userData[Strings.userAddressAlias]);

            //This roundabout for selecting the state is needed for some reason
            IWebElement stateDDL = GetWaitForClickableElement(Strings.stateDdlXP);
            stateDDL = stateDDL.FindElement(By.Id(Strings.statesDdlID));
            selectElement = new SelectElement(stateDDL);
            selectElement.SelectByText(userData[Strings.userState]);

            GetWaitForClickableElement(Strings.registerConfirmXP).Click();
        }

        private static void TestProducts()
        {
            WaitForPageLoad();
            GetWaitForClickableElement(Strings.womenSectionXP).Click();

            WaitForPageLoad();
            IWebElement sortBy = GetWaitForClickableElement(Strings.sortByXP);
            sortBy = sortBy.FindElement(By.Id(Strings.sortByID));
            SelectElement selectElement = new SelectElement(sortBy);
            selectElement.SelectByText(Strings.sortByProductNameVal);
            WaitForSeconds();

            IWebElement colorTemp = GetWaitForClickableElement(Strings.filterByColorXP);
            colorTemp = colorTemp.FindElement(By.XPath(Strings.filterByBlackVal));
            colorTemp.Click();
            WaitForSeconds();

            IWebElement minValue = GetWaitForClickableElement(Strings.priceRangeMinXP);
            IWebElement maxValue = GetWaitForClickableElement(Strings.priceRangeMaxXP);
            IWebElement priceRange = GetWaitForClickableElement(Strings.priceRangeValueXP);
            AdjustSliderValue(priceRange, minValue, maxValue);
            WaitForSeconds();

            Actions actions = new Actions(driver);
            IWebElement itemToBuy = GetWaitForClickableElement(Strings.itemToBuyXP);
            actions.MoveToElement(itemToBuy).Perform();
            GetWaitForClickableElement(Strings.productToAddXP).Click();
            WaitForSeconds();
            GetWaitForClickableElement(Strings.continueShoppingXP).Click();
        }

        private static void AdjustSliderValue(IWebElement priceRange, IWebElement minValue, IWebElement maxValue)
        {
            //TO-DO
        }

        private static void AfterShoppingTest()
        {
            GetWaitForClickableElement(Strings.contactUsXP).Click();
            WaitForSeconds();
            GetWaitForClickableElement(Strings.contactMessageXP).SendKeys(Strings.GenerateContactMessage());

            //Roundabout needed again
            IWebElement subjectDDL = GetWaitForClickableElement(Strings.subjectHeadingDDLXP);
            subjectDDL = subjectDDL.FindElement(By.Id(Strings.subjectHeadingID));
            SelectElement selectElement = new SelectElement(subjectDDL);
            selectElement.SelectByValue("1");

            GetWaitForClickableElement(Strings.sendMessageBtnXP).Click();
            WaitForSeconds(5);

            try
            {
                GetWaitForClickableElement(Strings.contactSuccessXP);
                Console.WriteLine("Message sent succesfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sending the message did not succeed!");
                Console.WriteLine(ex.Message);
            }
        }

        private static void FinishShopping()
        {
            GetWaitForClickableElement(Strings.myProfileXP).Click();
            WaitForPageLoad();
            GetWaitForClickableElement(Strings.myInformationXP).Click();
            WaitForPageLoad();
            GetWaitForClickableElement(Strings.cartXP).Click();
            WaitForPageLoad();
            
            //Roundabout
            IWebElement checkout = GetWaitForClickableElement(Strings.toCheckoutWrapperXP);
            checkout = checkout.FindElement(By.XPath("//span"));
            checkout.Click();
            GetWaitForClickableElement(Strings.toCheckoutXP).Click();
            WaitForPageLoad();
            GetWaitForClickableElement(Strings.confirmAddressXP).Click();
            WaitForPageLoad();
            GetWaitForClickableElement(Strings.termsOfServiceXP).Click();
            GetWaitForClickableElement(Strings.confirmShippingXP).Click();
            WaitForPageLoad();
            GetWaitForClickableElement(Strings.bankPaymentXP).Click();
            WaitForPageLoad();
            GetWaitForClickableElement(Strings.confirmOrderXP).Click();
            WaitForPageLoad();

            GetWaitForClickableElement(Strings.myProfileXP).Click();
            WaitForPageLoad();
            GetWaitForClickableElement(Strings.orderHistoryXP).Click();
            WaitForPageLoad();
            GetOrderData();
            GetWaitForClickableElement(Strings.expandLatestOrderXP).Click();
            GetWaitForClickableElement(Strings.latestOrderPDFXP).Click();
        }

        private static void CreateNewUserData()
        {
            userData.Add(Strings.userGender, Strings.GenerateGender() ? Strings.male : Strings.female);
            userData.Add(Strings.userName, Strings.GenerateName(userData[Strings.userGender]));
            userData.Add(Strings.userLastName, Strings.GenerateLastName());
            userData.Add(Strings.userEmail, Strings.GenerateEmail());
            userData.Add(Strings.userPassword, Strings.GeneratePassword());
            userData.Add(Strings.userBirth, Strings.GenerateDateOfBirth());
            userData.Add(Strings.userAddress, Strings.GenerateAddress());
            userData.Add(Strings.userCity, Strings.GenerateCity());
            userData.Add(Strings.userState, Strings.GenerateState());
            userData.Add(Strings.userZip, Strings.GenerateZIP());
            userData.Add(Strings.userPhone, Strings.GeneratePhoneNumber());
            userData.Add(Strings.userAddressAlias, Strings.GenerateAddressAlias());
        }

        #region HelperFunctions

        private static IWebElement GetWaitForClickableElement(string elementRX)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(defaultTimeout));
            IWebElement temp = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(elementRX)));
            return temp;
        }

        private static IWebElement GetWaitForVisibleElement(string elementRX)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(defaultTimeout));
            IWebElement temp = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(elementRX)));
            return temp;
        }

        private static void WaitForPageLoad()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(defaultTimeout)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void WaitForSeconds(int seconds = 10, int maxTimeOutSeconds = 60)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, maxTimeOutSeconds));
            var delay = new TimeSpan(0, 0, 0, 0, seconds * 1000);
            var timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);
        }

        private static void DisplayUserData()
        {
            foreach (KeyValuePair<string, string> item in userData)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }

        private static void GetOrderData()
        {
            IWebElement orderReference = GetWaitForClickableElement(Strings.lastOrderReferenceXP);
            IWebElement orderDate = GetWaitForClickableElement(Strings.lastOrderDateXP);
            IWebElement orderPrice = GetWaitForClickableElement(Strings.lastOrderPriceXP);
            orderData.Add(Strings.orderReference, orderReference.Text);
            orderData.Add(Strings.orderDate, orderDate.Text);
            orderData.Add(Strings.orderPrice, orderPrice.Text);
        }

        private static void DisplayOrderData()
        {
            foreach (KeyValuePair<string, string> item in orderData)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
        #endregion
    }
}