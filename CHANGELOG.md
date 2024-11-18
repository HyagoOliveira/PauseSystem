# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [Unreleased]
### Changed
- Refact ScriptableObject PauseSettings -> static class PauseManager
- Rename PauseAudioSource -> PauseAudioSources

### Removed
- IPauseSettings interface

## [1.1.0] - 2022-01-13
### Added
- Awaitable Coroutines package dependency
- PauseBehaviours

### Fixed
- Time.deltaTime is not 0F when OnResume is invoked

## [1.0.0] - 2022-01-12
### Added
- PauseAudioSource
- PauseUnityEvent
- PauseSettings
- OnPaused event
- OnResumed event

### Changed
- Bump Unity version into 2021.2

## [0.1.0] - 2020-01-23
### Added
- Add CHANGELOG
- Add README
- Add initial files
- Initial commit

[Unreleased]: https://github.com/HyagoOliveira/PauseSystem/compare/1.1.0...main
[1.1.0]: https://github.com/HyagoOliveira/PauseSystem/tree/1.1.0/
[1.0.0]: https://github.com/HyagoOliveira/PauseSystem/tree/1.0.0/
[0.1.0]: https://github.com/HyagoOliveira/PauseSystem/tree/0.1.0/