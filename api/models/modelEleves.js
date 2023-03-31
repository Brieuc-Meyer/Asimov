/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
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

    async modelAfficherNotesUnEleve(req, res) {


        return new Promise((resolve, reject) => {
            //ORDER BY afin que pas de mutuelle soit selected
            let eleve_id = req.params.eleve_id

            let requeteSQL = 'SELECT * FROM notes WHERE note_eleve_id = ?'
            mysqlConnexion.query(requeteSQL,[eleve_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    }


}