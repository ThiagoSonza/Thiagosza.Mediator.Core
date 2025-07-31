# Changelog

Todas as mudan�as relevantes deste projeto ser�o documentadas aqui.

O formato � baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/)
e este projeto adere ao [Semantic Versioning](https://semver.org/lang/pt-BR/).

---

## [1.0.5] - 2025-07-31

### Adicionado

- Correções nas injeções das dependências do Mediator para Scoped.

## [1.0.0] - 2025-06-25

### Adicionado

- Primeira vers�o est�vel do pacote `Thiagosza.Mediator.Core`.
- Interface `IMediator` com m�todos `Send<T>` e `Publish`.
- Suporte a `IRequest`e `IRequestHandler<>` compat�veis com commands e queries.
- Integra��o com DI via `IServiceCollection.AddMediator(...)`.
- Exemplos b�sicos no README.
