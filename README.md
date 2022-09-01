# Sample Zoom Meeting SDK C# Signature Generator

This is a sample C# console app that generates an encrypted SDK JSON Web Token (JWT) for Zoom Meeting SDK. This helps developers to quickly generate JWT token using the [SDK App Type](https://marketplace.zoom.us/docs/guides/build/sdk-app/) credentials.

JWT is generated based on the following core parts as stated in the [documentation](https://marketplace.zoom.us/docs/sdk/native-sdks/auth#generate-the-sdk-jwt). 

## Prerequisite
- [Visual Studio Code](https://code.visualstudio.com/) with the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) installed. For information about how to install extensions on Visual Studio Code, see [VS Code Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-marketplace).
- [The .NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

## Build
1. Open *Program.cs* and provide the following specification - SDK App Key, SDK Secret, Meeting Number and Role Type. Refer to our documentation for [specification](https://marketplace.zoom.us/docs/sdk/native-sdks/auth#generate-the-sdk-jwt).

    ```csharp
        public class Program {

        static void Main (string[] args) {
            Console.WriteLine ("Generate Web SDK Token...");
            
            // Replace with your SDK API Key
            string apiKey = "SDK_API_KEY";

            // Replace with your SDK API Secret
            string apiSecret = "SDK_API_SECRET";

            // Replace with a Meeting Number
            string meetingNumber = "MEETING_NUMBER";

            // role: 0 for participant, 1 for host
            int role = 1; 
    ```

2. In terminal, run the following command to build the project:

    ```Console
    dotnet build
    ```
    These will install any needed dependencies, build the project, and run the project respectively.

3. Run the program:

    ```Console
    dotnet run
    ```

## Sample Output

Below is a sample output you should see in your terminal. 

```Console
Generate Web SDK Token...

eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzZGtLZXkiOiIyV0RlVloyR0VwRmdBMzFJTFJMY0hEY1VMVWNKUzg1NVR5ZVciLCJtbiI6IjEyMzEyMzEyMzQiLCJyb2xlIjoxLCJpYXQiOjE2NTc2OTQxNDgsImV4cCI6MTY1NzcwMTM0OCwiYXBwS2V5IjoiMldEZVZaMkdFcEZnQTMxSUxSTGNIRGNVTFVjSlM4NTVUeWVXIn0.qfqOm744FttzRZfOblJvIsRguHPUOgojMtRTcxfte3k
```
