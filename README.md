# 586Project

This is the back end Web API repository.

Built with ASP.Net Core 3.0.

The database context is configured through the appsettings, which is pointing to an AWS RDS endpoint.

1) The project is deployed through AWS Elastic Beanstalk to a .NET/IIS environment.
2) A CloudFront distribution, with a CNAME of "api.authorsandblogs.com", is redirecting HTTP requests to the Beanstalk URL to HTTPS.
3) Route 53 was used to set the A record for the domain "api.authorsandblogs.com" to the URL of the CloudFront distribution.
