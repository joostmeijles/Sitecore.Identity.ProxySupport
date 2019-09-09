# Sitecore Identity reverse-proxy support
By default Sitecore Identity Server 9.1 does not support reverse-proxy forwarding.
See [this](https://sitecore.stackexchange.com/questions/20841/identity-server-behind-reverse-proxy-not-reachable-by-cm) question at Sitecore Stack Exchange for details.

This plugin adds reverse-proxy support for the Sitecore Identity Server. It does this by injecting a small piece of ASP.NET Core middleware and by adding a `PublicOrigin` configuration option.

# Applying the solution
To apply the solution:
- Build the project
- Copy the Sitecore.Identity.ProxySupport.dll assembly to `C:\inetpub\wwwroot\identity\sitecoreruntime\production`
- Copy `Sitecore.Plugin.manifest` and `Config/` directory to `C:\inetpub\wwwroot\identity\sitecoreruntime\production\sitecore\Sitecore.Identity.ProxySupport\`
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
- Configure the `PublicOrigin` in `config/proxysupport.xml`


The above follows the standard way of working for a Sitecore Host plugin as defined here:
https://doc.sitecore.com/developers/91/sitecore-experience-management/en/add-a-runtime-plugin-manually.html

> NB. When you apply steps don't forget to stop the `w3wp` process

# Credits
Special thanks to [Per Bering](https://github.com/pbering) for providing the code for this solution.