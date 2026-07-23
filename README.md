# .NET Aspire Samples

<!-- portfolio-badges:start -->
<!-- Identity -->
[![phmatray - aspire-samples](https://img.shields.io/static/v1?label=phmatray&message=aspire-samples&color=blue&logo=github)](https://github.com/phmatray/aspire-samples)
![Top language](https://img.shields.io/github/languages/top/phmatray/aspire-samples)
[![Stars](https://img.shields.io/github/stars/phmatray/aspire-samples?style=social)](https://github.com/phmatray/aspire-samples/stargazers)
[![Forks](https://img.shields.io/github/forks/phmatray/aspire-samples?style=social)](https://github.com/phmatray/aspire-samples/network/members)
[![License](https://img.shields.io/github/license/phmatray/aspire-samples)](https://github.com/phmatray/aspire-samples/blob/HEAD/LICENSE)

<!-- Activity -->
[![Issues](https://img.shields.io/github/issues/phmatray/aspire-samples)](https://github.com/phmatray/aspire-samples/issues)
[![Pull requests](https://img.shields.io/github/issues-pr/phmatray/aspire-samples)](https://github.com/phmatray/aspire-samples/pulls)
[![Last commit](https://img.shields.io/github/last-commit/phmatray/aspire-samples)](https://github.com/phmatray/aspire-samples/commits)
<!-- portfolio-badges:end -->


> A collection of **.NET Aspire** demos — each folder is a self-contained sample
> showing how to orchestrate a different integration with Aspire.

Previously scattered across separate repositories, now consolidated in one place
(full git history preserved). Open the solution in a sample folder and run its
`AppHost` project.

## Samples

| Sample | Shows | From |
|---|---|---|
| [`samples/n8n-automation`](samples/n8n-automation) | Aspire orchestrating an **n8n** automation container | `phmatray/aspire-app-with-n8n` ★ |
| [`samples/strapi-cms`](samples/strapi-cms) | Aspire + **Strapi 5** headless CMS + Blazor + StrawberryShake + PostgreSQL | `phmatray/AspireStrapi` |
| [`samples/micro-frontends`](samples/micro-frontends) | Aspire with **4 service styles** — REST, gRPC, GraphQL, CoreWCF | `phmatray/AspireAppWithMicroFrontends` |
| [`samples/prestashop`](samples/prestashop) | Aspire integrating **PrestaShop** e-commerce via containers + REST | `phmatray/AspirePrestashop` |
| [`samples/tickerq-notifications`](samples/tickerq-notifications) | Aspire + **TickerQ** — scheduled background jobs & email notifications | `phmatray/AspireTickerQ` |
| [`samples/container-orchestration`](samples/container-orchestration) | Aspire **container orchestration** & service composition basics | `phmatray/AspireContainer` |

## Running a sample

```bash
git clone https://github.com/phmatray/aspire-samples.git
cd aspire-samples/samples/<sample>
dotnet run --project <the AppHost project>
```

Each sample requires the [.NET Aspire workload](https://learn.microsoft.com/dotnet/aspire/) and Docker.

## History

Each sample was merged with **full git history preserved** (`git subtree`). The
original repositories are archived and redirect here.

<!-- portfolio-techstack:start -->

## Tech Stack

- **.NET 8**
- Aspire.Hosting
- Microsoft.Extensions.Http.Resilience
- Microsoft.Extensions.ServiceDiscovery
- OpenTelemetry.Exporter.OpenTelemetryProtocol
- OpenTelemetry.Extensions.Hosting
- OpenTelemetry.Instrumentation.AspNetCore
- OpenTelemetry.Instrumentation.GrpcNetClient
- OpenTelemetry.Instrumentation.Http

<!-- portfolio-techstack:end -->

<!-- portfolio-roadmap:start -->

## Roadmap

Planned work and known limitations are tracked in the [open issues](https://github.com/phmatray/aspire-samples/issues). Contributions toward them are welcome.

<!-- portfolio-roadmap:end -->

## License

MIT — see [`LICENSE`](LICENSE).

---

<!-- portfolio-sections:start -->

## Contributing

Contributions are welcome. Open an issue first to discuss any significant change.

1. Fork the repository and create your branch (`git checkout -b feat/my-feature`)
2. Commit your changes (`git commit -m 'feat: ...'`)
3. Push the branch and open a Pull Request

<!-- portfolio-sections:end -->
