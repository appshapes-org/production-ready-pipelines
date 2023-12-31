# Production Ready Pipelines

<table>
  <tr>
    <th>GitLab</th><td><a href="https://gitlab.com/Rjae/production-ready-pipelines/-/pipelines"><img src="https://gitlab.com/Rjae/production-ready-pipelines/badges/master/pipeline.svg" /></a></td><td><a href="https://production-ready-pipelines-rjae-b1b991fe5be258c306785611c6e0f6d.gitlab.io/"><img src="https://gitlab.com/Rjae/production-ready-pipelines/-/jobs/artifacts/master/raw/.ignored/coverage-reports/badge_combined.svg?job=test" /></a></td>
  </tr>
  <tr>
    <th>GitHub</th><td><a href="https://github.com/appshapes-org/production-ready-pipelines/actions/workflows/.github-ci.yml"><img src="https://github.com/appshapes-org/production-ready-pipelines/actions/workflows/.github-ci.yml/badge.svg" /></a></td><td><a href="https://appshapes-org.github.io/production-ready-pipelines/"><img src="https://appshapes-org.github.io/production-ready-pipelines/badge_combined.svg" /></a></td>
  </tr>
</table>

# What is this for?

This repository contains production-ready pipeline implementations for GitLab, GitHub, Jenkins, and Harness.

# Who is this for?

Developers, platform engineers, and others may use this repository setting up and/or improving pipelines.

# What is here?

## Docker Compose

- `docker-compose.yml` for running Api and Tests components.
- `docker-compose-tools.yml` for running GitLab, Jenkins, and Harness instances locally.
- `.gitlab-ci.yml` configures GitLab pipeline.

# What are the dependencies?

- Docker

# How do I run GitLab pipeline?

You need a GitLab project and runner to run the GitLab pipeline. Either run the GitLab Docker image, or use GitLab.com.

## Locally Hosted

The following resources are excellent and can get you up and running locally quickly:

- [How to install GitLab using Docker Compose?](https://www.czerniga.it/2021/11/14/how-to-install-gitlab-using-docker-compose/)
- GitLab Docs > Install > Installation methods > [Docker](https://docs.gitlab.com/ee/install/docker.html)
- And then follow the steps under "GitLab Hosted"

## GitLab Hosted

- Fork [production-ready-pipelines](https://github.com/appshapes-org/production-ready-pipelines)
- [Create a repository mirror](https://docs.gitlab.com/ee/user/project/repository/mirror/#create-a-repository-mirror) to your fork
