# IOX 3rd party API Documentation: http://redocly.github.io/redoc/?url=https://stagingintegration.ioxfleet.co.za/swagger/v1/swagger.json

## Iox Settings Configuration
Iox will provide you with:
    1. tenant_id
    2. username
    3. api-key

Open the iox_sample_application's appsettings.json file and replace the tenant_id, username, and api-key provided by IOX.


## Endpoint Configuration

To receive updates from the iox api you'll need to configure a webhook.

Test Webhook Setup:
1. Download ngrok (https://ngrok.com/download)
2. Run ngrok.exe 
3. In the command line window run ngrok http 5008 the iox_sample_app listens on port 5008.
4. To configure your endpoint navigate to the EndPointController/Configure replace 'YourSharedKeyProvidedWhenSettingUpEndpoint' with a valid shared key. Then replace {Your_ngrok_url} with the ngrok https url (e.g. https://66fcf8608ec6.ngrok.io) the url value should look like:  https://66fcf8608ec6.ngrok.io/endpoint/response 
5. Start the iox_sample_application, open your browser and navigate to http://localhost:5008/endpoint/configure




  
  

   