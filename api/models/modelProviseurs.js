/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
 * @Crédits : Lorenzo Porcu => aide sur les Promesses 
*/


//récuperer le module de connexion
let modelConnexion = require('./modelConnexion.js')
let mysqlConnexion = modelConnexion.mysqlConnexion

//export des methodes contenant les requettes SQL
module.exports = {

    /**
     * Médhodes d'instantiations des promesses de résultat de  @requetteSQL 
     * si @err est true la promesse est @return rejeté @reject avec le message d'erreur @err
     * sinon @return @resolve avec les donnés @data de la @requetteSQL
     * !  on ne peut résolve q'une @data par promesse  !
    */

    async modelAfficherTousLesEleves(req) {

        return new Promise((resolve, reject) => {
            let requeteSQL = `SELECT eleves.eleve_id, eleves.eleve_identifiant, eleves.eleve_mdp ,eleves.eleve_nom, classes.class_nom, classes.class_id
            FROM  eleves, classes 
            WHERE eleve_class_id = class_id`

            mysqlConnexion.query(requeteSQL, (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
    async modelAfficherToutesLesMatieres(req) {

        return new Promise((resolve, reject) => {
            let requeteSQL = `SELECT * FROM  matieres`

            mysqlConnexion.query(requeteSQL, (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },


    async modelAjouterMatiere(req) {


        return new Promise((resolve, reject) => {

            let mat_nom = req.params.mat_nom

            let requeteSQL = "INSERT INTO matieres (mat_nom) VALUES (?)"


            mysqlConnexion.query(requeteSQL, [mat_nom], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelSupprimerMatiere(req) {


        return new Promise((resolve, reject) => {

            let mat_id = req.params.mat_id

            let requeteSQL = "DELETE FROM matieres WHERE mat_id = ?;"


            mysqlConnexion.query(requeteSQL, [mat_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },



    async modelModifMatiere(req) {



        return new Promise((resolve, reject) => {

            let mat_nom = req.params.mat_nom
            let mat_id = req.params.mat_id


            let requeteSQL = 'UPDATE matieres SET mat_nom = ? WHERE mat_id = ?'
            mysqlConnexion.query(requeteSQL, [mat_nom, mat_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
    // pour connaitre la matière de la note que le prof assigne
    async modelAfficherProfesseurs() {

        return new Promise((resolve, reject) => {

            let requeteSQL = `SELECT * FROM personnels WHERE perso_proviseur_on = 0 `

            mysqlConnexion.query(requeteSQL, (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
    async modelAfficherClasses() {

        return new Promise((resolve, reject) => {

            let requeteSQL = `SELECT * FROM classes `

            mysqlConnexion.query(requeteSQL, (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelAjouterClasse(req) {


        return new Promise((resolve, reject) => {

            let class_nom = req.params.class_nom

            let requeteSQL = "INSERT INTO classes (class_nom) VALUES (?)"


            mysqlConnexion.query(requeteSQL, [class_nom], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelSupprimerClasse(req) {


        return new Promise((resolve, reject) => {

            let class_id = req.params.class_id

            let requeteSQL = "DELETE FROM classes WHERE class_id = ?;"


            mysqlConnexion.query(requeteSQL, [class_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },



    async modelModifClasse(req) {



        return new Promise((resolve, reject) => {

            let class_nom = req.params.class_nom
            let class_id = req.params.class_id


            let requeteSQL = 'UPDATE classes SET class_nom = ? WHERE class_id = ?'
            mysqlConnexion.query(requeteSQL, [class_nom, class_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelAjouterPersonnel(req) {


        return new Promise((resolve, reject) => {
            let perso_nom = req.params.perso_nom
            let perso_identifiant = req.params.perso_identifiant
            let perso_mdp = req.params.perso_mdp
            let perso_proviseur_on = req.params.perso_proviseur_on

            let requeteSQL = "INSERT INTO personnels (perso_nom, perso_identifiant, perso_mdp, perso_proviseur_on) VALUES (?, ?, ?, ?)"


            mysqlConnexion.query(requeteSQL, [perso_nom, perso_identifiant, perso_mdp, perso_proviseur_on], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },



    async modelModifPersonnel(req) {



        return new Promise((resolve, reject) => {


            let perso_nom = req.params.perso_nom
            let perso_identifiant = req.params.perso_identifiant
            let perso_mdp = req.params.perso_mdp
            let perso_proviseur_on = req.params.perso_proviseur_on
            let perso_id = req.params.perso_id



            let requeteSQL = 'UPDATE personnels SET perso_nom = ?, perso_identifiant = ?, perso_mdp = ?, perso_proviseur_on = ?  WHERE perso_id = ?'
            mysqlConnexion.query(requeteSQL, [perso_nom, perso_identifiant, perso_mdp, perso_proviseur_on, perso_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelSupprimerPersonnel(req) {


        return new Promise((resolve, reject) => {

            let perso_id = req.params.perso_id

            let requeteSQL = "DELETE FROM personnels WHERE perso_id = ?;"


            mysqlConnexion.query(requeteSQL, [perso_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
    async modelAssignerClasse(req) {


        return new Promise((resolve, reject) => {

            let perso_id = req.params.perso_id
            let class_id = req.params.class_id


            let requeteSQL = "INSERT INTO liaison_personnel_classes (perso_id, class_id) VALUES (?, ?)"


            mysqlConnexion.query(requeteSQL, [perso_id, class_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelSuprimmerAssignationClasse(req) {


        return new Promise((resolve, reject) => {

            let perso_id = req.params.perso_id
            let class_id = req.params.class_id


            let requeteSQL = "DELETE FROM liaison_personnel_classes WHERE perso_id = ? AND class_id= ?"


            mysqlConnexion.query(requeteSQL, [perso_id, class_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelAssignerMatiere(req) {


        return new Promise((resolve, reject) => {

            let perso_id = req.params.perso_id
            let mat_id = req.params.mat_id

            let requeteSQL = "INSERT INTO liaison_personnel_matieres (perso_id, mat_id) VALUES (?, ?)"


            mysqlConnexion.query(requeteSQL, [perso_id, mat_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
    async modelSuprimmerAssignationMatiere(req) {


        return new Promise((resolve, reject) => {

            let perso_id = req.params.perso_id
            let mat_id = req.params.mat_id

            let requeteSQL = "DELETE FROM liaison_personnel_matieres WHERE perso_id = ? AND mat_id= ?"


            mysqlConnexion.query(requeteSQL, [perso_id, mat_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },
}

