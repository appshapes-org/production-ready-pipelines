down:
	docker compose down

image:
	docker build --build-arg PROJECT=$(service) -f $(service)/Dockerfile -t $(service) .

image-run:
	docker run --name $(service) -it --rm --entrypoint $(command) $(service)

image-sh:
	docker exec -it $(service) sh

stop:
	docker compose stop $(service)

up:
	docker compose build $(service)
	docker compose up -d $(service)