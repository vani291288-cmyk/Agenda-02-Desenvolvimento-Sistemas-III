# Agenda 07 — Tempo Agora

Aplicativo da **Agenda 07 — Desenvolvimento Mobile II / Desenvolvimento de Sistemas III**, desenvolvido em .NET MAUI com consumo da API OpenWeather.

## Implementações da atividade

### Parte 1 — Expandindo os dados exibidos
A aplicação exibe:
- descrição textual do clima;
- velocidade do vento;
- visibilidade;
- além dos dados que já eram apresentados.

### Parte 2 — Tratamento de erros
A aplicação:
- identifica cidade não encontrada por meio de `HttpResponseMessage.StatusCode`;
- apresenta alerta específico quando não há conexão com a internet.

## Build
O repositório possui um workflow em `.github/workflows/build-agenda07.yml` para compilar a versão Android e publicar o APK como artefato do GitHub Actions.

## Base
Projeto baseado no exemplo de aula `MauiAppTempoAgora` disponibilizado pelo professor Tiago Antonio da Silva.

## Tecnologias
- C#
- .NET MAUI
- HTTP / HttpClient
- OpenWeather API
- Newtonsoft.Json
