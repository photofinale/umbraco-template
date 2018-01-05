# AgeBase Umbraco Template

**AgeBase Umbraco Template** is a hopefully handy template for creating Umbraco web applications. It includes your usual Umbraco features and also some nice extra features. Things like automated deployments, strongly typed models, donut caching, gulp scripts and Azure hosting. We've also added some handy scripts to managed Umbraco databases and setting up a development machine to run the template.

### Features

This project is a work in progress. We have a desired feature list which shows what we've completed so far. If you'd like to add a feature suggestion, please create an issue or even better, send the repository a pull request. Below is a list of what has been completed so far. To view our backlog, please visit our [project page](../../projects/1).

- Web
 - [x] [Domain Manager](src/AgeBaseTemplate/app_plugins/AgeBase.DomainManager)
 - [x] [Robots.txt](src/AgeBaseTemplate/robots.txt)
 - [x] [Output Caching](src/AgeBaseTemplate/web.config#L82)
 - [x] [Http Compression](src/AgeBaseTemplate/web.config#L358)
 - [x] [Force Https](src/AgeBaseTemplate/web.config#L385)
 - [x] [Force Remove WWW](src/AgeBaseTemplate/web.config#L392)
 - [x] [Force Trailing Slash](src/AgeBaseTemplate/web.config#L399)
 - [x] [Mime Types](src/AgeBaseTemplate/web.config#L309)
- UI
 - [x] [Gulp](src/AgeBaseTemplate.UI/gulpfile.js)
 - [x] [Bower](src/AgeBaseTemplate.UI/bower.json)
 - [x] [Sass](src/AgeBaseTemplate.UI/sass)
 - [x] [Js](src/AgeBaseTemplate.UI/js)
 - [x] [Source Maps](src/AgeBaseTemplate.UI/gulpfile.js#L21)
 - [x] [Minification](src/AgeBaseTemplate.UI/gulpfile.js#L37)
 - [x] [Compression](src/AgeBaseTemplate.UI/gulpfile.js#L42)
- Core
 - [x] [uSync](src/AgeBaseTemplate/usync/data)
 - [x] [Models Builder](src/AgeBaseTemplate.Core/ContentTypes)
 - [x] [Core Value Converters](src/AgeBaseTemplate.Core/packages.config#L35)
 - [x] [Simple Injector](src/AgeBaseTemplate.Core/Global/GlobalApplication.cs#L25)
 - [x] [Unit Tests](tests/AgeBaseTemplate.Core.Tests)
- Deployment
 - [x] [Appveyor](appveyor.yml)
 - [x] [Slack Notifications](appveyor.yml#L53)
 - [x] [Continuous Deployment](appveyor.yml#L46)
 - [x] [Database Restore](appveyor.yml#L42)
 - [x] [Automatic Versioning](appveyor.yml#L9)
- Azure
 - [x] [Load Balancing](../../commit/4dcb8634382ea6d8e1c97f11cf393fedafe21b36)
- Misc
 - [x] [Clean Script](scripts/Repo.Clean.bat)
 - [x] [Database Backup Script](scripts/Database.Backup.bat)
 - [x] [Database Clean Script](scripts/Database.Clean.bat)
 - [x] [Database Drop Script](scripts/Database.Drop.bat)
 - [x] [Database Restore Script](scripts/Database.Restore.bat)