using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

[TestFixture]
public class SpringappApplicationTests
{
    private HttpClient _httpClient;
    private string _generatedToken;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://8080-aabdbffdadabafcfdbcfacbdcbaeadbebabcdebdca.premiumproject.examly.io"); 
    }

    [Test, Order(1)]
    public async Task Backend_TestRegisterUser()
    {
        string uniqueId = Guid.NewGuid().ToString();
 
        // Generate a unique userName based on a timestamp
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";
 
        string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"Role\": \"customer\"}}";
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
 
        Console.WriteLine(response.StatusCode);
        string responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);
 
        // Assuming you get a 200 OK status for successful registration
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
 
    [Test, Order(2)]
    public async Task Backend_TestLoginUser()
    {
        string uniqueId = Guid.NewGuid().ToString();
 
        string uniqueusername = $"abcd_{uniqueId}";
        string uniquepassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";
        string uniquerole = "customer";
        string requestBody = $"{{\"Username\": \"{uniqueusername}\", \"Password\": \"{uniquepassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"Role\" : \"{uniquerole}\" }}";
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
 
        string requestBody1 = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquepassword}\"}}";
        HttpResponseMessage response1 = await _httpClient.PostAsync("/api/login", new StringContent(requestBody1, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
        string responseBody = await response1.Content.ReadAsStringAsync();
    }
 
    [Test, Order(3)]
    public async Task Backend_TestRegisterAdmin()
    {
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";
 
        string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"Role\": \"admin\"}}";
       
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
 
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        // Add your assertions based on the response if needed
    }
 
    [Test, Order(4)]
    public async Task Backend_TestLoginAdmin()
    {
        string uniqueId = Guid.NewGuid().ToString();
 
        string uniqueusername = $"abcd_{uniqueId}";
        string uniquepassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";
        string uniquerole = "admin";
        string requestBody = $"{{\"Username\": \"{uniqueusername}\", \"Password\": \"{uniquepassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"Role\" : \"{uniquerole}\" }}";
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
 
        string requestBody1 = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquepassword}\"}}";
        HttpResponseMessage response1 = await _httpClient.PostAsync("/api/login", new StringContent(requestBody1, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
        string responseBody = await response1.Content.ReadAsStringAsync();
    }

//     [Test]
// public async Task Backend_TestAddAddon()
// {
//     // Assuming registration and login have already been done in previous test cases

//     // Use a dynamic and unique userName for admin (appending timestamp)
//     string uniqueUsername = $"admin_{Guid.NewGuid()}";
//     string uniqueEmail = $"abcd{Guid.NewGuid()}@gmail.com";

//     // Register the admin user
//     string adminRegistrationRequestBody = $"{{\"password\": \"abc@123A\", \"Username\": \"{uniqueUsername}\",\"role\": \"admin\",\"email\": \"{uniqueEmail}\"}}";
//     HttpResponseMessage adminRegistrationResponse = await _httpClient.PostAsync("/api/register", new StringContent(adminRegistrationRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, adminRegistrationResponse.StatusCode);

//     // Login the admin user
//     string adminLoginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"abc@123A\"}}";
//     HttpResponseMessage adminLoginResponse = await _httpClient.PostAsync("/api/login", new StringContent(adminLoginRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, adminLoginResponse.StatusCode);
//     string adminLoginResponseBody = await adminLoginResponse.Content.ReadAsStringAsync();
//     dynamic adminLoginResponseMap = JsonConvert.DeserializeObject(adminLoginResponseBody);

//     // Store the generated token
//     _generatedToken = adminLoginResponseMap.token;
//     var uniqueAddonName = "addon"
//     // Create addon data
//     string uniqueAddonName = $"addon_{Guid.NewGuid()}";
//     decimal addonPrice = 10.99m;
//     string addonDetails = "test description";
//     string addonValidity = "test validity";

//     // Update the addonJson to match your Swagger JSON structure
//     string addonJson = $"{{\"userId\": {adminLoginResponseMap.userId}, \"addonName\":\"{uniqueAddonName}\",\"addonPrice\":{addonPrice},\"addonDetails\":\"{addonDetails}\",\"addonValidity\":\"{addonValidity}\"}}";

//     // Set Authorization header with the stored token
//     _httpClient.DefaultRequestHeaders.Clear();  // Clear any existing headers
//     _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _generatedToken);

//     // Send request to AddAddon endpoint
//     HttpResponseMessage addonResponse = await _httpClient.PostAsync("/api/addAddon",
//         new StringContent(addonJson, Encoding.UTF8, "application/json"));

//     // Print response content in case of failure
//     if (addonResponse.StatusCode != HttpStatusCode.OK)
//     {
//         string responseContent = await addonResponse.Content.ReadAsStringAsync();
//         Console.WriteLine($"Response Content: {responseContent}");
//     }

//     // Assert the response status code is OK
//     Assert.AreEqual(HttpStatusCode.OK, addonResponse.StatusCode);
// }
[Test]
public async Task Backend_TestAddAddon()
{
    // Generate unique identifiers
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueusername = $"abcd_{uniqueId}";
    string uniquepassword = $"abcdA{uniqueId}@123";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    // Register a customer
    string registerRequestBody = $"{{\"Username\": \"{uniqueusername}\", \"Password\": \"{uniquepassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"Role\" : \"admin\" }}";
    HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

    // Login the registered customer
    string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquepassword}\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
    string customerAuthToken = loginResponseMap.token;

    // Use the obtained token in the request to add an addon
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

    var review = new
    {
        AddonValidity = "Test subject",
        AddonDetails = "Test body",
        AddonPrice = 5,
        AddonName = "sample name"
    };

    string addonRequestBody = JsonConvert.SerializeObject(review);
    HttpResponseMessage addonResponse = await _httpClient.PostAsync("api/addAddon", new StringContent(addonRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, addonResponse.StatusCode);
}

[Test]
public async Task Backend_TestUpdateAddon()
{
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueusername = $"abcd_{uniqueId}";
    string uniquepassword = $"abcdA{uniqueId}@123";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    // Registration and login logic (same as above)
    
    // Use the obtained token in the requests
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

    // Rest of the test case_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

    // Add an addon
    var addAddonReview = new
    {
        AddonValidity = "Test subject",
        AddonDetails = "Test body",
        AddonPrice = 5,
        AddonName = "sample name"
    };

    string addAddonRequestBody = JsonConvert.SerializeObject(addAddonReview);
    HttpResponseMessage addAddonResponse = await _httpClient.PostAsync("api/addAddon", new StringContent(addAddonRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, addAddonResponse.StatusCode);

    // Get addons to find the id of the added addon
    HttpResponseMessage getAddonsResponse = await _httpClient.GetAsync("api/getAddon");
    Assert.AreEqual(HttpStatusCode.OK, getAddonsResponse.StatusCode);
    string getAddonsResponseBody = await getAddonsResponse.Content.ReadAsStringAsync();
    var addons = JsonConvert.DeserializeObject<List<Addon>>(getAddonsResponseBody);
    Assert.IsNotNull(addons);
    Assert.IsTrue(addons.Any());

    // Update the first addon
    var updatedAddon = new
    {
        AddonValidity = "Updated subject",
        AddonDetails = "Updated body",
        AddonPrice = 10,
        AddonName = "updated name"
    };

    string updateAddonRequestBody = JsonConvert.SerializeObject(updatedAddon);
    long addonIdToUpdate = addons.First().Id; // Assuming Id property exists in Addon model
    HttpResponseMessage updateAddonResponse = await _httpClient.PutAsync($"api/editAddon/{addonIdToUpdate}", new StringContent(updateAddonRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, updateAddonResponse.StatusCode);
}


}