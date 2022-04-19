
namespace Zadatak5
{
    internal class Strings
    {
        internal static string url = "http://automationpractice.com/index.php";

        #region Register XPath
        internal static string signInBtnXP = "//a[@class='login']";
        internal static string emailInputXP = "//*[@id='email_create']";
        internal static string createAccBtnXP = "//button[@id='SubmitCreate']";
        internal static string maleRdXP = "//input[@id='id_gender1']";
        internal static string femaleRdXP = "//input[@id='id_gender2']";
        internal static string nameTxtXP = "//input[@id='customer_firstname']";
        internal static string lastNameTxtXP = "//input[@id='customer_lastname']";
        internal static string emailTxtXP = "//input[@id='email']";
        internal static string passwordTxtXP = "//input[@id='passwd']";
        internal static string dayDdlXP = "//select[@id='days']";
        internal static string monthDdlXP = "//select[@id='months']";
        internal static string yearDdlXP = "//select[@id='years']";
        internal static string addressXP = "//input[@id='address1']";
        internal static string cityXP = "//input[@id='city']";
        internal static string stateDdlXP = "//*[@id='uniform-id_state']";
        internal static string postalXP = "//input[@id='postcode']";
        internal static string phoneNumberXP = "//input[@id='phone_mobile']";
        internal static string addressAliasXP = "//input[@id='alias']";
        internal static string registerConfirmXP = "//button[@id='submitAccount']";
        internal static string statesDdlID = "id_state";
        #endregion

        #region Products XPath
        internal static string womenSectionXP = "//li/a[@title='Women']";
        internal static string sortByXP = "//div[@id='uniform-selectProductSort']";
        internal static string sortByProductNameVal = "Product Name: A to Z";
        internal static string sortByID = "selectProductSort";
        internal static string filterByColorXP = "//label[@class='layered_color']";
        internal static string filterByBlackVal = "//a[text()= \"Black\"]";
        internal static string priceRangeMinXP = "//div[@id='layered_price_slider']/a[1]";
        internal static string priceRangeMaxXP = "//div[@id='layered_price_slider']/a[2]";
        internal static string priceRangeValueXP = "//span[@id='layered_price_range']";
        internal static string productToAddXP = "//div[@class='product-container']//div[descendant::a[@title='Blouse']]//a[contains(@class, 'add_to_cart_button')]";
        internal static string continueShoppingXP = "//span[@title='Continue shopping']";
        internal static string itemToBuyXP = "//div[@class='product-container']//div[descendant::a[@title='Blouse']]";
        #endregion

        #region Post-shopping XPath
        internal static string contactUsXP = "//a[@title='Contact us']";
        internal static string contactUsEmailXP = "//input[@id='email']";
        internal static string orderReferenceXP = "//input[@id='id_order']";
        internal static string contactMessageXP = "//textarea[@id='message']";
        internal static string subjectHeadingDDLXP = "//div[@id='uniform-id_contact']";
        internal static string subjectHeadingXP = "//select[@id='id_contact']";
        internal static string sendMessageBtnXP = "//button[@id='submitMessage']";
        internal static string contactSuccessXP = "//p[@class='alert alert-success']";
        internal static string subjectHeadingID = "id_contact";
        #endregion

        #region Finish Shopping XPath
        internal static string myProfileXP = "//div[@class='header_user_info']/a[@class='account']";
        internal static string myInformationXP = "//a[@title='Information']";
        internal static string cartXP = "//a[@title='View my shopping cart']";
        internal static string toCheckoutWrapperXP = "//p[contains(@class, 'cart_navigation')]";
        internal static string toCheckoutXP = "//p[contains(@class, 'cart_navigation']/a[1]";
        internal static string confirmAddressXP = "//button[@name='processAddress']";
        internal static string termsOfServiceXP = "//input[@id='cgv']";
        internal static string confirmShippingXP = "//button[@name='processCarrier']";
        internal static string bankPaymentXP = "//a[@class='bankwire']";
        internal static string confirmOrderXP = "//button[@class='button btn btn-default button-medium']";
        internal static string orderHistoryXP = "//a[@title='Orders']";
        internal static string expandLatestOrderXP = "//table[@id='order-list']//tr[contains(@class, 'first_item')]//span[@class='footable-toggle']";
        internal static string latestOrderPDFXP = "//table[@id='order-list']//tr[contains(@class, 'first_item')]//a[@class='Invoice']";
        #endregion

        #region Order Details XPath
        internal static string lastOrderReferenceXP = "//table[@id='order-list']//tr[contains(@class, 'first_item')]//a[@class='color-myaccount']";
        internal static string lastOrderDateXP = "//table[@id='order-list']//tr[contains(@class, 'first_item')]//td[contains(@class, 'history_date')]";
        internal static string lastOrderPriceXP = "//table[@id='order-list']//tr[contains(@class, 'first_item')]//span[@class='price']";
        #endregion

        #region UserData Keys
        internal static string userEmail = "Email";
        internal static string userName = "Name";
        internal static string userLastName = "Last name";
        internal static string userPassword = "Password";
        internal static string userGender = "Gender";
        internal static string userBirth = "Date of birth";
        internal static string userAddress = "Address";
        internal static string userCity = "City";
        internal static string userState = "State";
        internal static string userZip = "ZIP code";
        internal static string userPhone = "Phone number";
        internal static string userAddressAlias = "Address alias";
        internal static string male = "M";
        internal static string female = "F";
        #endregion

        #region OrderData Keys 
        internal static string orderReference = "Order Reference";
        internal static string orderDate = "Date";
        internal static string orderPrice = "Total Price";
        #endregion

        #region Data-filling Strings
        private static string emailDomain = "@mailinator.com";
        private static string[] namesM = { "Matthew", "Mark", "Frodo", "Rex", "Magni" };
        private static string[] namesF = { "Samantha", "Kate", "Jaina", "Tali", "Valeera", "Shirley" };
        private static string[] lastNames = { "Grayson", "Hoxton", "Ripley", "Raimi", "Craven", "Manson", "O'Hara" };
        private static string[] addresses = { "221B Baker Street", "0001 Cemetery Lane", "42 Wallaby Way", "112 1/2 Beacon St.", "742 Evergreen Terrace" };
        private static string[] cities = { "Derry", "Gotham", "Mos Eisly", "Falador", "Haddonfield", "Pawnee", "Gravity Falls" };
        private static string[] states = { "New York", "Oregon", "Washington", "California", "Maine", "Florida", "Kansas", "South Dakota", "Texas" };
        private static string[] aliases = { "Home", "Work", "Evil Lair", "Underground Lab", "Upside Down", "Catacombs" };
        #endregion

        private static Random rand = new Random();
        private static int phoneNumberLength = 10;

        #region Data Generating
        internal static string GenerateEmail()
        {
            string email = "test_";
            email += DateTime.Now.ToString("yyyyMMdd_HHmmss");
            email += emailDomain;
            return email;
        }

        internal static bool GenerateGender()
        {
            return rand.Next(1, 3) % 2 == 0; 
        }

        internal static string GenerateName(string gender)
        {
            if(gender.Equals(male))
            {
                return namesM[rand.Next(0, namesM.Length)];
            }
            else
            {
                return namesF[rand.Next(0, namesF.Length)];
            }
        }
        internal static string GenerateLastName()
        {
            return lastNames[rand.Next(0, lastNames.Length)];
        }

        internal static string GeneratePassword()
        {
            string temp = "PWD-";
            temp += DateTime.Now.ToString("HHmmss-yyyyMMdd");
            return temp;
        }

        internal static string GenerateDateOfBirth()
        {
            DateTime start = new DateTime(1900, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range)).ToShortDateString();
        }

        internal static string GenerateAddress()
        {
            return addresses[rand.Next(0, addresses.Length)];
        }

        internal static string GenerateCity()
        {
            return cities[rand.Next(0, cities.Length)];
        }

        internal static string GenerateState()
        {
            return states[rand.Next(0, states.Length)];
        }

        internal static string GenerateZIP()
        {
            return rand.Next(0, 99999).ToString().PadLeft(5, '0');
        }

        internal static string GeneratePhoneNumber()
        {
            string temp = "";
            for(int i = 0; i < phoneNumberLength; i++)
            {
                temp += rand.Next(0, 10).ToString();
            }

            return temp;
        }
        internal static string GenerateAddressAlias()
        {
            return aliases[rand.Next(0, aliases.Length)];
        }

        internal static string GenerateOrderReference()
        {
            return rand.Next(1, 99999).ToString();
        }

        internal static string GenerateContactMessage()
        {
            //TO-DO
            return "This is a temporary contact form message!";
        }
        #endregion
    }
}