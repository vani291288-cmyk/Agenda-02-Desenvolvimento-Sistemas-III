# Agenda 07 — Tempo Agora

Aplicativo desenvolvido em .NET MAUI com consumo da API OpenWeather.

## Alterações da Agenda 7

### Parte 1 — Expandindo os dados exibidos
A aplicação passou a exibir:
- descrição textual do clima;
- velocidade do vento;
- visibilidade.

### Parte 2 — Tratamento de erros
A aplicação passou a:
- informar quando a cidade não é encontrada, usando `HttpResponseMessage.StatusCode`;
- apresentar alerta específico quando ocorre falha de conexão com a internet.

## Base
Projeto baseado no exemplo de aula `MauiAppTempoAgora` disponibilizado pelo professor Tiago Antonio da Silva.

## Tecnologias
- C#
- .NET MAUI
- HTTP / HttpClient
- OpenWeather API
- Newtonsoft.Json
