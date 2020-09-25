# IOX API sample application

The IOX API is an asynchronous instruction processor, instructions are added to a queue and the IOX Core application is responsible for processing these instructions. Once an instruction is processed the result will be POSTED to a webhook.

## IOX API Document:
https://github.com/iox-consulting/api_sample_app/blob/master/iox_sample_app/docs/IOX%20API.pdf

## IOX API Swagger: 
http://redocly.github.io/redoc/?url=https://stagingintegration.ioxfleet.co.za/swagger/v1/swagger.json

## Iox Settings Configuration
Iox will provide you with:
1. tenant_id
2. username
3. api-key

Open the iox_sample_application's appsettings.json file and replace the tenant_id, username, and api-key.

Please note: the sample application is configured to point to the IOX staging environment.

## Endpoint Configuration

To receive updates from the iox api you'll need to configure a webhook.

ngrok setup to receive Webhook calls locally:
1. Download ngrok (https://ngrok.com/download)
2. Run ngrok.exe 
3. In the command line window run ngrok http 5008 the iox_sample_app listens on port 5008.
4. To configure your endpoint navigate to the EndPointController/Configure replace 'YourSharedKeyProvidedWhenSettingUpEndpoint' with a valid shared key. Then replace {Your_ngrok_url} with the ngrok https url (e.g. https://66fcf8608ec6.ngrok.io) the url value should look like:  https://66fcf8608ec6.ngrok.io/endpoint/response 
5. Start the iox_sample_application, open your browser and navigate to http://localhost:5008/endpoint/configure




  
  

   
