/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
 * @Crédits : Lorenzo Porcu => aide sur les Promesses 

 * @mysql2 => Gère les process asynchones,
 *         => Améliore les transactions gestion des grandes quantitées de données et des procédures stockées,
 *         => Connection pool systématique, automatise aqquérir / relacher les connections
 * @iniparser => lis / parse les ficier .ini, afin de faire des .gitignore de ces derniers et de protèger ses accès,
*/ 
let mysql = require('mysql2');
let iniparser = require('iniparser')
let configDB = iniparser.parseSync('./DB.ini')


const mysqlConnexion = mysql.createConnection({
    host: configDB['dev']['host'],
    user: configDB['dev']['user'],
    password: configDB['dev']['password'],
    database: configDB['dev']['dbname']
})
mysqlConnexion.connect((err) => {
    if (!err) console.log('BDD connectée.')
    else console.log('BDD connexion échouée \n Erreur: ' + JSON.stringify(err))
});



const modeltestConnexionEleves = (req, res) => {

    return new Promise((resolve, reject) => {

        let identifiant = req.params.eleve_identifiant
        let mdp = req.params.eleve_mdp
        //la serrure est l'identifiant, on vérifiera ctrlConnexion si l'utilisateur connait la clé
        let requeteSQL = 'SELECT * FROM eleves WHERE eleve_identifiant = ? AND eleve_mdp = ?'
        mysqlConnexion.query(requeteSQL, [identifiant, mdp], (err, data) => {

            if (err) {
                return reject()
            }
            return resolve(data)
        })
    }
    )
}
const modeltestConnexionPersonnels = (req, res) => {

    return new Promise((resolve, reject) => {

        let identifiant = req.params.perso_identifiant
        let mdp = req.params.perso_mdp
        //la serrure est l'identifiant, on vérifiera ctrlConnexion si l'utilisateur connait la clé
        let requeteSQL = 'SELECT * FROM  personnels WHERE perso_identifiant = ? AND perso_mdp = ?'
        mysqlConnexion.query(requeteSQL, [identifiant, mdp], (err, data) => {

            if (err) {
                return reject()
            }
            return resolve(data)
        })
    }
    )
}


module.exports = {
    mysqlConnexion,
    modeltestConnexionEleves,
    modeltestConnexionPersonnels
    
} 