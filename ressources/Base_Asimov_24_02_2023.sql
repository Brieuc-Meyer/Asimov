CREATE TABLE [dbo].[classes](
    [class_grade] BIGINT NOT NULL,
    [class_nom] BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([class_grade] ASC)
);

CREATE TABLE [dbo].[eleves](
    [eleve_id] BIGINT IDENTITY(1,1) NOT NULL,
    [eleve_nom] VARCHAR(255) NOT NULL,
    [eleve_identifiant] VARCHAR(255) NOT NULL,
    [eleve_mdp] VARCHAR(255) NOT NULL,
    [eleve_class_grade] BIGINT NOT NULL,
    CONSTRAINT [eleves_eleve_class_grade_foreign] FOREIGN KEY ([eleve_class_grade]) REFERENCES [dbo].[classes] ([class_grade]),
    PRIMARY KEY CLUSTERED ([eleve_id] ASC)
);

CREATE TABLE [dbo].[personnels](
    [perso_id] BIGINT IDENTITY(1,1) NOT NULL,
    [perso_mat_id] BIGINT NOT NULL,
    [perso_nom] VARCHAR(255) NOT NULL,
    [perso_identifiant] VARCHAR(255) NOT NULL,
    [perso_mdp] VARCHAR(255) NOT NULL,
    [perso_proviseur_on] TINYINT NOT NULL,
    PRIMARY KEY CLUSTERED ([perso_id] ASC)
);

CREATE TABLE [dbo].[matieres](
    [mat_id] BIGINT IDENTITY(1,1) NOT NULL,
    [mat_nom] VARCHAR(255) NOT NULL,
    PRIMARY KEY CLUSTERED ([mat_id] ASC)
);

CREATE TABLE [dbo].[notes](
    [note_id] BIGINT IDENTITY(1,1) NOT NULL,
    [note_pourcent] FLOAT(8) NOT NULL,
    [note_prof_id] BIGINT NOT NULL,
    [note_mat_id] BIGINT NOT NULL,
    [note_date_evaluation] DATE NOT NULL,
    [note_intitule] VARCHAR(50) NOT NULL,
    [note_description] VARCHAR(255) NOT NULL,
    CONSTRAINT [notes_note_prof_id_foreign] FOREIGN KEY ([note_prof_id]) REFERENCES [dbo].[personnels] ([perso_id]),
    CONSTRAINT [notes_note_mat_id_foreign] FOREIGN KEY ([note_mat_id]) REFERENCES [dbo].[matieres] ([mat_id]),
    PRIMARY KEY CLUSTERED ([note_id] ASC)
);

CREATE TABLE [dbo].[liaison_personnel_matieres](
    [perso_id] BIGINT IDENTITY(1,1) NOT NULL,
    [mat_id] BIGINT NOT NULL,
    CONSTRAINT [liaison_personnel_matieres_perso_id_foreign] FOREIGN KEY ([perso_id]) REFERENCES [dbo].[personnels] ([perso_id]),
    CONSTRAINT [liaison_personnel_matieres_mat_id_foreign] FOREIGN KEY ([mat_id]) REFERENCES [dbo].[matieres] ([mat_id])
);

CREATE TABLE [dbo].[liaision_personnel_classes](
    [perso_id] BIGINT IDENTITY(1,1) NOT NULL,
    [class_grade] BIGINT NOT NULL,
    CONSTRAINT [liaision_personnel_classes_perso_id_primary] PRIMARY KEY CLUSTERED ([perso_id] ASC),
    CONSTRAINT [liaision_personnel_classes_class_grade_foreign] FOREIGN KEY ([class_grade]) REFERENCES [dbo].[classes] ([class_grade])
);