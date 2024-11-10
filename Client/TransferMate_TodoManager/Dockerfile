# Stage 1: Build the Angular application
FROM node:22-alpine AS build
WORKDIR /app

# Install dependencies only if package.json or package-lock.json changes
COPY package.json package-lock.json ./
RUN npm install --silent

# Copy the rest of the application code
COPY . .

# Build the Angular application
RUN npm run build --prod

# Stage 2: Serve the application with Nginx
FROM nginx:alpine
COPY --from=build /app/dist/transfer-mate-todo-manager/browser /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

