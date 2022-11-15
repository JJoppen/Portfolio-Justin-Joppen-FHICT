FROM openjdk:13-alpine
RUN apk --no-cache add curl
Volume /tmp
ADD /target/*.jar springbootgitlab-0.0.1-SNAPSHOT.jar
ENTRYPOINT ["java","-jar","/springbootgitlab-0.0.1-SNAPSHOT.jar"]
EXPOSE 8080
