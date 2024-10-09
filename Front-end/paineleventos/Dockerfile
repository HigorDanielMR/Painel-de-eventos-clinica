FROM node:18-alpine as build-stage
WORKDIR /app
RUN npm i @quasar/cli
COPY package*.json ./
RUN npm i
COPY . .
RUN npm run build

# publish stage
FROM nginx:mainline-alpine3.20-slim as production-stage
COPY --from=build-stage /app/dist/spa /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

