# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/).

## [Unreleased]

### Added

- MIT license file
- CODEOWNERS file for automatic PR review assignment
- CI workflow for .NET Aspire project
- EditorConfig for consistent code formatting
- Issue templates for bug reports and feature requests
- Pull request template
- Renovate configuration for automated dependency updates

### Changed

- Major dependency upgrades via Renovate (MudBlazor v9, Aspire Hosting v13, HotChocolate v15, StrawberryShake v15, Tailwind CSS v4, DaisyUI v5, .NET monorepo v10, CoreWCF v10)
- Updated OpenTelemetry packages to 1.15.0
- Updated gRPC .NET packages to 2.76.0
- Updated YARP Reverse Proxy to 2.3.0

## [0.1.0] - 2023-11-28

### Added

- Initial project setup with .NET Aspire and micro frontends architecture
- Blazor WebAssembly module system with dynamic NavMenu integration
- WCF Core service integration
- gRPC server and client communication
- GraphQL API with HotChocolate and StrawberryShake
- MudBlazor UI framework with authentication support
- Kanban board page
- WebShell projects for micro frontend hosting
- HTMX app server integration
- Tailwind CSS with DaisyUI for styling
- Writerside documentation setup
- Solution filters for focused development
- .NET Analyzers and StyleCop configuration
