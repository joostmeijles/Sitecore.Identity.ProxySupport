This plugin adds reverse-proxy support for the Sitecore Identity Server.

To enable it;
- Build the project
- Copy the Sitecore.Identity.ProxySupport.dll assembly to `C:\inetpub\wwwroot\identity\sitecoreruntime\production`
- Copy `Sitecore.Plugin.manifest` and `Config/` directory to `C:\inetpub\wwwroot\identity\sitecoreruntime\production\sitecore`
- As plugin load order is import, add `Sitecore.Identity.ProxySupport` as dependency to `C:\inetpub\wwwroot\identity\sitecore\Sitecore.Plugin.IdentityServer\Sitecore.Plugin.manifest`, e.g:
```
<?xml version="1.0" encoding="utf-8"?>
<SitecorePlugin PluginName="Sitecore.Plugin.IdentityServer" AssemblyName="Sitecore.Plugin.IdentityServer" Version="2.0.1-r00166">
  <Dependencies>
    <Dependency name="Sitecore.Plugin.IdentityProviders">2.0.1-r00166</Dependency>
    <Dependency name="Sitecore.Identity.ProxySupport"></Dependency>
  </Dependencies>
  <Tags>
    <Sitecore>Sitecore</Sitecore>
  </Tags>
</SitecorePlugin>
```
- Configure the `PublicOrigin` in `proxysupport.xml`


The above follows the standard way of working for a Sitecore Host plugin as defined here:
https://doc.sitecore.com/developers/91/sitecore-experience-management/en/add-a-runtime-plugin-manually.html

NB. When you do this don't forget to stop the `w3wp` process
