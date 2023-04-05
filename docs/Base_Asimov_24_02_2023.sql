DROP DATABASE IF EXISTS asimov;
CREATE DATABASE asimov;
USE  asimov;

CREATE TABLE `classes` (
    `class_grade` BIGINT NOT NULL,
    `class_nom` VARCHAR(30) NOT NULL,
    PRIMARY KEY (`class_grade`)
)ENGINE=InnoDB;

CREATE TABLE `eleves` (
    `eleve_id` BIGINT AUTO_INCREMENT PRIMARY KEY,
    `eleve_nom` VARCHAR(50) NOT NULL,
    `eleve_identifiant` VARCHAR(50) NOT NULL,
    `eleve_mdp` VARCHAR(10) NOT NULL,
    `eleve_class_grade` BIGINT NOT NULL,
    CONSTRAINT `fk_eleve_class` FOREIGN KEY (`eleve_class_grade`) REFERENCES `classes` (`class_grade`)
)ENGINE=InnoDB;

CREATE TABLE `personnels` (
    `perso_id` BIGINT AUTO_INCREMENT PRIMARY KEY,
    `perso_nom` VARCHAR(50) NOT NULL,
    `perso_identifiant` VARCHAR(50) NOT NULL,
    `perso_mdp` VARCHAR(10) NOT NULL,
    `perso_proviseur_on` TINYINT NOT NULL
)ENGINE=InnoDB;

CREATE TABLE `matieres` (
    `mat_id` BIGINT AUTO_INCREMENT PRIMARY KEY,
    `mat_nom` VARCHAR(50) NOT NULL
)ENGINE=InnoDB;

CREATE TABLE `notes` (
    `note_id` BIGINT AUTO_INCREMENT PRIMARY KEY,
    `note_eleve_id` BIGINT NOT NULL,
    `note_pourcent` FLOAT(8) NOT NULL,
    `note_prof_id` BIGINT NOT NULL,
    `note_mat_id` BIGINT NOT NULL,
    `note_date_evaluation` DATE NOT NULL,
    `note_intitule` VARCHAR(50) NOT NULL,
    `note_description` VARCHAR(255) NOT NULL,
    CONSTRAINT `fk_note_eleve` FOREIGN KEY (`note_eleve_id`) REFERENCES `eleves` (`eleve_id`) ON DELETE CASCADE,
    CONSTRAINT `fk_note_prof` FOREIGN KEY (`note_prof_id`) REFERENCES `personnels` (`perso_id`),
    CONSTRAINT `fk_note_mat` FOREIGN KEY (`note_mat_id`) REFERENCES `matieres` (`mat_id`)
)ENGINE=InnoDB;

CREATE TABLE `liaison_personnel_matieres` (
    `perso_id` BIGINT NOT NULL,
    `mat_id` BIGINT NOT NULL,
    CONSTRAINT `fk_liaison_personnel_matieres_perso` FOREIGN KEY (`perso_id`) REFERENCES `personnels` (`perso_id`),
    CONSTRAINT `fk_liaison_personnel_matieres_mat` FOREIGN KEY (`mat_id`) REFERENCES `matieres` (`mat_id`)
)ENGINE=InnoDB;

CREATE TABLE `liaison_personnel_classes` (
    `perso_id` BIGINT NOT NULL,
    `class_grade` BIGINT NOT NULL,
    CONSTRAINT `fk_liaison_personnel_classes_perso` FOREIGN KEY (`perso_id`) REFERENCES `personnels` (`perso_id`),
    CONSTRAINT `fk_liaison_personnel_classes_class` FOREIGN KEY (`class_grade`) REFERENCES `classes` (`class_grade`)
)ENGINE=InnoDB;


INSERT INTO `classes` (`class_grade`, `class_nom`) VALUES
    (6, 'Sixieme'),
    (5, 'Cinquieme'),
    (4, 'Quatrieme'),
    (3, 'Troisieme');

INSERT INTO `eleves` (`eleve_nom`, `eleve_identifiant`, `eleve_mdp`, `eleve_class_grade`) VALUES
    ('Jean Dupont', 'jean.dupont', 'root', 6),
    ('Sophie Martin', 'sophie.martin', 'root', 5),
    ('Pierre Durand', 'pierre.durand', 'root', 4);

INSERT INTO `personnels` (`perso_nom`, `perso_identifiant`, `perso_mdp`, `perso_proviseur_on`) VALUES
    ('Jeanne Dupuis', 'jeanne.dupuis', 'root', 1),
    ('Marc Leroy', 'marc.leroy', 'root', 0),
    ('Sophie Dupont', 'sophie.dupont', 'root', 0);

INSERT INTO `matieres` (`mat_nom`) VALUES
    ('Mathematiques'),
    ('Francais'),
    ('Anglais'),
    ('Histoire-Geographie');

INSERT INTO `liaison_personnel_matieres` (`perso_id`,`mat_id`) VALUES
    (2,1),
    (2,2),
    (3,3),
    (3,1);

INSERT INTO `liaison_personnel_classes` (`perso_id`,`class_grade`) VALUES
    (2,6),
    (2,5),
    (3,4),
    (3,3);

INSERT INTO `notes` (`note_eleve_id`,`note_pourcent`,`note_prof_id`,`note_mat_id`,`note_date_evaluation`,`note_intitule`,`note_description`) VALUES
    (1, 69, 1, 1, '2023-6-25', 'contôle maths juin', "vraiment técla, vraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment técla" ),
    (1, 7, 1, 1, '2023-6-7', 'contôle maths foiré juin', "vraiment técla, vraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment técla" ),
    (1, 75, 1, 2, '2023-6-1', 'contôle maths juin', "vraiment técla, vraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment técla" ),
    (1, 9, 1, 3, '2023-6-8', 'contôle maths juin', "vraiment técla, vraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment técla" ),
    (1, 35, 1, 4, '2023-6-15', 'contôle maths juin', "vraiment técla, vraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment téclavraiment técla" );
    