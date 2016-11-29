# AgeBase Umbraco Template

**AgeBase Umbraco Template** is a hopefully handy template for creating Umbraco web applications. It includes your usual Umbraco features and also some nice extra features. Things like automated deployments, strongly typed models, donut caching, gulp scripts and Azure hosting. We've also added some handy scripts to managed Umbraco databases and setting up a development machine to run the template.

[![Build status](https://ci.appveyor.com/api/projects/status/xu7qpbvmvlimlaew/branch/master?svg=true)](https://ci.appveyor.com/project/AgeBase/umbraco-template/branch/master)

### Features

The project is a work in progress. We have a desired feature list which shows what we've completed so far. If you'd like to add a feature suggestion, please send the repository a pull request.

- Umbraco
 - [ ] Base Template
 - [ ] Country Page
 - [ ] Home Page
 - [ ] Content Page
 - [ ] Contact Page
 - [ ] Legal Page
 - [ ] Search Page
 - [ ] Redirect Page
 - [ ] Error Page
 - [ ] Meta Properties
 - [ ] Navigation Properties
 - [ ] Seo Properties
 - [ ] Umbraco Properties
 - [ ] Site Configuration
 - [ ] Site Redirects
 - [ ] Site Messages
 - [ ] Multiple Sites
- Web
 - [x] [Domain Manager](src/AgeBaseTemplate/app_plugins/AgeBase.DomainManager)
 - [x] [Robots.txt](src/AgeBaseTemplate/robots.txt)
 - [ ] Sitemap.xml
 - [ ] Favicon
 - [x] [Output Caching](src/AgeBaseTemplate/web.config#L77)
 - [x] [Http Compression](src/AgeBaseTemplate/web.config#L355)
 - [x] [Force Https](src/AgeBaseTemplate/web.config#L382)
 - [x] [Force Remove WWW](src/AgeBaseTemplate/web.config#L389)
 - [x] [Force Trailing Slash](src/AgeBaseTemplate/web.config#L396)
 - [x] [Mime Types](src/AgeBaseTemplate/web.config#L306)
- UI
 - [x] [Gulp](src/AgeBaseTemplate.UI/gulpfile.js)
 - [x] [Bower](src/AgeBaseTemplate.UI/bower.json)
 - [ ] Sass
 - [ ] JavaScript
 - [ ] Compression
 - [ ] Minification
 - [ ] Unit Tests
- Core
 - [x] [uSync](src/AgeBaseTemplate/usync/data)
 - [x] [Models Builder](src/AgeBaseTemplate.Core/ContentTypes)
 - [x] [Core Value Converters](src/AgeBaseTemplate.Core/packages.config#L33)
 - [x] [Simple Injector](src/AgeBaseTemplate.Core/Global/GlobalApplication.cs#L24)
 - [ ] Send Grid
 - [ ] Unit Tests
- Deployment
 - [x] [Appveyor](appveyor.yml)
 - [x] [Slack Notifications](appveyor.yml#L56)
 - [x] [Continuous Deployment](appveyor.yml#L51)
 - [x] [Database Restore](appveyor.yml#L47)
 - [ ] Media Restore
 - [x] [Automatic Versioning](appveyor.yml#L12)
- Azure
 - [ ] Resource Template
 - [ ] Dedicated Back Office
 - [x] [Load Balancing](commit/4dcb8634382ea6d8e1c97f11cf393fedafe21b36)
 - [ ] Media CDN
 - [ ] Assets CDN
 - [ ] Examine CDN
 - [ ] Logging CDN
 - [ ] Alerts
 - [ ] Backups
- Misc
 - [x] [Clean Script](scripts/Repo.Clean.bat)
 - [x] [Database Backup Script](scripts/Database.Backup.bat)
 - [x] [Database Clean Script](scripts/Database.Clean.bat)
 - [x] [Database Drop Script](scripts/Database.Drop.bat)
 - [x] [Database Restore Script](scripts/Database.Restore.bat)
 - [ ] Setup Script