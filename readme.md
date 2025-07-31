# DotNet.Mediator.Core

Uma biblioteca leve, extensível e moderna para aplicações .NET que seguem o padrão Mediator. Com suporte a injeção de dependência, handlers assíncronos e behaviors customizados, o DotNet.Mediator.Core é ideal para arquiteturas baseadas em CQRS e clean architecture.

---

## ✨ Recursos

- Envio de **comandos** e **consultas** com handlers fortemente tipados
- Suporte a **pipelines (middlewares)** via behaviors
- Integração nativa com **injeção de dependência (DI)** do .NET
- Foco em **simplicidade**, **testabilidade** e **performance**
- Inspirado em [MediatR](https://github.com/jbogard/MediatR)

---

## 📦 Instalação

```bash
dotnet add package Thiagosza.Mediator.Core
```

Ou edite seu .csproj:

```bash
<PackageReference Include="Thiagosza.Mediator.Core" Version="1.0.5" />
```

## 🚀 Exemplo de Uso

Defina um comando ou consulta

```csharp
public record ClassCommand(string Nome) : IRequest<string>;
```

Crie o handler correspondente

```csharp
public class ClassHandler : IRequestHandler<ClassCommand, string>
{
    public async Task<string> Handle(ClassCommand request, CancellationToken cancellationToken = default)
    {
        return await Task.Run(() => "Executado com sucesso");
    }
}
```

Crie a controller

```csharp
[ApiController]
[Route("[controller]")]
public class WeatherForecastController() : ControllerBase
{
    [HttpPost(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get(
        [FromBody] ClassCommand command,
        IMediator mediator)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
```

E registrar no `Program.cs`:

```csharp
builder.Services.AddMediator();
```
