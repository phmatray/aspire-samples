# .NET Aspire Samples

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

## License

MIT — see [`LICENSE`](LICENSE).
