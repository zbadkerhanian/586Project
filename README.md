# AuthorsAPI

This is the back end Web API repository hosted with the domain "https://api.authorsandblogs.com".

Built with ASP.Net Core 3.0.

The database context is configured through the appsettings, which is pointing to an AWS RDS endpoint.

1) The project is deployed through AWS Elastic Beanstalk to a .NET/IIS environment.
2) HTTPS redirection done is differently for the API. The Beanstalk instance was configured for load balancing, and a listener was added on port 443 of the load balancer and set to redirect HTTPS to HTTP.
3) Route 53 was used to set the A record for the domain "api.authorsandblogs.com", which had an SSL certificate from AWS Certificate Manager, to the Beanstalk URL.
