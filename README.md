# 🌐 ApiConsume

Bu proje; bağımsız bir Web API backend servisinin (**News**) hem bir **MVC** uygulaması (**ContactApp**) hem de bir **Razor Pages** uygulaması (**TodoApp**) tarafından tüketilmesini modelleyen entegre bir .NET çözümüdür.

### 📌 Mimarî Yapı
* **News:** Sistemin veri sağlayıcı RESTful Web API backend katmanı.
* **ContactApp:** API servislerini tüketen ASP.NET Core MVC uygulaması.
* **TodoApp:** API servislerini DTO ve Typed HttpClient ile tüketen Razor Pages uygulaması.

### 🛠️ Teknolojiler
.NET, C#, ASP.NET Core (Web API, MVC, Razor Pages), Entity Framework Core, REST, Swagger, Bootstrap.
## Related Projects

This solution brings together and extends three of my earlier standalone projects:

- [NewsApp-WebAPI](https://github.com/ZehraAslantas/NewsApp-WebAPI) – The backend Web API that serves news data
- [ContactApp---Web](https://github.com/ZehraAslantas/ContactApp---Web) – Original ASP.NET Core MVC contact app
- [TodoApp](https://github.com/ZehraAslantas/TodoApp) – Original ASP.NET Core Razor Pages task app
