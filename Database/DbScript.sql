CREATE DATABASE  IF NOT EXISTS `dev` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dev`;
-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: dev
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `codigo`
--

DROP TABLE IF EXISTS `codigo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `codigo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `lenguaje_id` int DEFAULT NULL,
  `nivel` int DEFAULT NULL,
  `segmento` int DEFAULT NULL,
  `codigo` varchar(2000) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `lenguaje_id_idx` (`lenguaje_id`),
  CONSTRAINT `lenguaje_id` FOREIGN KEY (`lenguaje_id`) REFERENCES `lenguajes` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=499 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `codigo`
--

LOCK TABLES `codigo` WRITE;
/*!40000 ALTER TABLE `codigo` DISABLE KEYS */;
INSERT INTO `codigo` VALUES (463,1,0,0,'public class Main {\n    public static void main(String[] args) {'),(464,1,0,1,'        String nombre = \"Ana\";'),(465,1,0,2,'        System.out.println(\"Nombre: \" + nombre);\n    }\n}'),(466,1,1,0,'public class Main {\n    public static void main(String[] args) {\n        private String nombre;\n    }'),(467,1,1,1,'    public String getNombre() {\n        return nombre;\n    }'),(468,1,1,2,'    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),(469,1,2,0,'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre, int edad) {\n        this.nombre = nombre;\n    }'),(470,1,2,1,'    public String getNombre() {\n        return nombre;\n    }'),(471,1,2,2,'    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),(472,1,3,0,'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),(473,1,3,1,'public class Estudiante extends Persona {\n    private String carrera;\n\n    public Estudiante(String nombre, String carrera) {\n        super(nombre);\n        this.carrera = carrera;\n    }'),(474,1,3,2,'    public String getCarrera() {\n        return carrera;\n    }\n    public void setCarrera(String carrera) {\n        this.carrera = carrera;\n    }\n}'),(475,1,4,0,'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),(476,1,4,1,'public class Estudiante {\n    private String carrera;\n    private Persona persona; // Agregacion: Estudiante tiene una Persona\n\n    public Estudiante(String nombre, String carrera) {\n        this.persona = new Persona(nombre); // Crear una nueva Persona\n        this.carrera = carrera;\n    }'),(477,1,4,2,'    public String getCarrera() {\n        return carrera;\n    }\n    public void setCarrera(String carrera) {\n        this.carrera = carrera;\n    }\n}'),(478,1,5,0,'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),(479,1,5,1,'public class Estudiante {\n    private String carrera;\n    private Persona persona; // Asociación: Estudiante conoce a Persona\n\n    public Estudiante(Persona persona, String carrera) {\n        this.persona = persona;\n        this.carrera = carrera;\n    }'),(480,1,5,2,'    public String getCarrera() {\n        return carrera;\n    }\n    public void setCarrera(String carrera) {\n        this.carrera = carrera;\n    }\n    public Persona getPersona() {\n        return persona;\n    }\n    public void setPersona(Persona persona) {\n        this.persona = persona;\n    }\n}'),(481,2,0,0,'#include <iostream>\n#include <string>\n\nint main() {\n'),(482,2,0,1,'    std::string nombre = \"Ana\";\n'),(483,2,0,2,'    std::cout << \"Nombre: \" << nombre << std::endl;\n    return 0;\n}'),(484,2,1,0,'#include <string>\n\nclass Main {\nprivate:\n    std::string nombre;\n\n'),(485,2,1,1,'public:\n    std::string getNombre() {\n        return nombre;\n    }\n'),(486,2,1,2,'    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};'),(487,2,2,0,'#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\n'),(488,2,2,1,'public:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n'),(489,2,2,2,'    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};'),(490,2,3,0,'#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};'),(491,2,3,1,'class Estudiante : public Persona {\nprivate:\n    std::string carrera;\n\npublic:\n    Estudiante(const std::string& nombre, const std::string& carrera)\n        : Persona(nombre), carrera(carrera) {}\n'),(492,2,3,2,'    std::string getCarrera() const {\n        return carrera;\n    }\n\n    void setCarrera(const std::string& carrera) {\n        this->carrera = carrera;\n    }\n};'),(493,2,4,0,'#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};'),(494,2,4,1,'class Estudiante {\nprivate:\n    std::string carrera;\n    Persona persona;\n\npublic:\n    Estudiante(const std::string& nombre, const std::string& carrera)\n        : persona(nombre), carrera(carrera) {}\n'),(495,2,4,2,'    std::string getCarrera() const {\n        return carrera;\n    }\n\n    void setCarrera(const std::string& carrera) {\n        this->carrera = carrera;\n    }\n\n    Persona getPersona() const {\n        return persona;\n    }\n};'),(496,2,5,0,'#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};'),(497,2,5,1,'class Estudiante {\nprivate:\n    std::string carrera;\n    Persona* persona;\n\npublic:\n    Estudiante(Persona* persona, const std::string& carrera) {\n        this->persona = persona;\n        this->carrera = carrera;\n    }\n'),(498,2,5,2,'    std::string getCarrera() const {\n        return carrera;\n    }\n\n    void setCarrera(const std::string& carrera) {\n        this->carrera = carrera;\n    }\n\n    Persona* getPersona() const {\n        return persona;\n    }\n\n    void setPersona(Persona* persona) {\n        this->persona = persona;\n    }\n};');
/*!40000 ALTER TABLE `codigo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estadisticas`
--

DROP TABLE IF EXISTS `estadisticas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estadisticas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `jugador_estadistica_id` int NOT NULL,
  `prestigio_lenguaje` int DEFAULT '1',
  `bits` bigint DEFAULT '0',
  `clics_totales` int DEFAULT '0',
  `mejoras_totales` int DEFAULT '0',
  `tiempo_jugado` int DEFAULT '0',
  `codigo_nivel` int DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `jugador_estadistica_id_idx` (`jugador_estadistica_id`),
  KEY `prestigio_lenguaje_idx` (`prestigio_lenguaje`),
  CONSTRAINT `jugador_estadistica_id` FOREIGN KEY (`jugador_estadistica_id`) REFERENCES `jugadores` (`id`),
  CONSTRAINT `prestigio_lenguaje` FOREIGN KEY (`prestigio_lenguaje`) REFERENCES `lenguajes` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estadisticas`
--

LOCK TABLES `estadisticas` WRITE;
/*!40000 ALTER TABLE `estadisticas` DISABLE KEYS */;
/*!40000 ALTER TABLE `estadisticas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jugadores`
--

DROP TABLE IF EXISTS `jugadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jugadores` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) COLLATE utf8mb4_spanish_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jugadores`
--

LOCK TABLES `jugadores` WRITE;
/*!40000 ALTER TABLE `jugadores` DISABLE KEYS */;
/*!40000 ALTER TABLE `jugadores` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `jugadores_AFTER_INSERT` AFTER INSERT ON `jugadores` FOR EACH ROW BEGIN
    -- Insertar en estadisticas
    INSERT INTO estadisticas (jugador_estadistica_id)
    VALUES (NEW.id);
    
    -- Insertar 6 mejoras para el nuevo jugador
    INSERT INTO mejoras_jugadores (jugador_id, mejora_id, nivel) VALUES
    (NEW.id, 1, 0),
    (NEW.id, 2, 0),
    (NEW.id, 3, 0),
    (NEW.id, 4, 0),
    (NEW.id, 5, 0),
    (NEW.id, 6, 0);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `lenguajes`
--

DROP TABLE IF EXISTS `lenguajes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lenguajes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `descripcion` varchar(200) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lenguajes`
--

LOCK TABLES `lenguajes` WRITE;
/*!40000 ALTER TABLE `lenguajes` DISABLE KEYS */;
INSERT INTO `lenguajes` VALUES (1,'Java','Java es un lenguaje de programación de propósito general, orientado a objetos, multiplataforma y de código abierto'),(2,'C++','Lenguaje de programación de propósito general, multiparadigma, que extiende las capacidades del lenguaje C al agregar nuevas características como la programación orientada a objetos.'),(3,'Visual Basic','Lenguaje de programación desarrollado por Microsoft, basado en BASIC, que se utiliza para crear aplicaciones de escritorio, web y aplicaciones dentro de la suite de Microsoft Office.');
/*!40000 ALTER TABLE `lenguajes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mejoras`
--

DROP TABLE IF EXISTS `mejoras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mejoras` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `descripcion` varchar(200) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `costo` int DEFAULT NULL,
  `tipo` varchar(20) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mejoras`
--

LOCK TABLES `mejoras` WRITE;
/*!40000 ALTER TABLE `mejoras` DISABLE KEYS */;
INSERT INTO `mejoras` VALUES (1,'Encapsulamiento','Es la técnica de ocultar la implementación interna de una clase, de modo que solo se puedan acceder y modificar sus datos a través de métodos específicos.',20,'Principios'),(2,'Clases','Es una plantilla o modelo que define las características y comportamientos de un tipo de objeto.',10,'Principios'),(3,'Herencia','Mecanismo que permite a una clase (clase derivada o subclase) obtener los atributos y métodos de otra clase (clase base o superclase) para reutilizarlos y ampliar su funcionalidad.',10,'Relaciones'),(4,'Agregación','Forma de asociar objetos donde un objeto \"tiene\" otro, pero la existencia del objeto \"parte\" no depende del objeto \"total\".',10,'Relaciones'),(5,'Asociación','Relación entre clases que permite a instancias de una clase interactuar con instancias de otra clase.',10,'Relaciones'),(6,'Polimorfismo','Capacidad de los objetos de diferentes clases de responder de forma diferente al mismo mensaje o método.',666,'Principios');
/*!40000 ALTER TABLE `mejoras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mejoras_jugadores`
--

DROP TABLE IF EXISTS `mejoras_jugadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mejoras_jugadores` (
  `jugador_id` int NOT NULL,
  `mejora_id` int NOT NULL,
  `nivel` int DEFAULT '0',
  PRIMARY KEY (`jugador_id`,`mejora_id`),
  KEY `mejora_id_idx` (`mejora_id`),
  CONSTRAINT `jugador_id` FOREIGN KEY (`jugador_id`) REFERENCES `jugadores` (`id`),
  CONSTRAINT `mejora_id` FOREIGN KEY (`mejora_id`) REFERENCES `mejoras` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mejoras_jugadores`
--

LOCK TABLES `mejoras_jugadores` WRITE;
/*!40000 ALTER TABLE `mejoras_jugadores` DISABLE KEYS */;
/*!40000 ALTER TABLE `mejoras_jugadores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'dev'
--

--
-- Dumping routines for database 'dev'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-04  3:09:34
