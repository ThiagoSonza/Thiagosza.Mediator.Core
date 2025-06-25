# Changelog

Todas as mudanças relevantes deste projeto serão documentadas aqui.

O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/)
e este projeto adere ao [Semantic Versioning](https://semver.org/lang/pt-BR/).

---

## [1.0.0] - 2025-06-25

### Adicionado
- Primeira versão estável do pacote `Thiagosza.Mediator.Core`.
- Interface `IMediator` com métodos `Send<T>` e `Publish`.
- Suporte a `IRequest`e `IRequestHandler<>` compatíveis com commands e queries.
- Integração com DI via `IServiceCollection.AddMediator(...)`.
- Exemplos básicos no README.

