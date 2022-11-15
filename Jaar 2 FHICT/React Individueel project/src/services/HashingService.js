import bcrypt from 'bcryptjs'

class HashingService{
    createHash(password){
        const HashedPassword = bcrypt.hashSync(password,bcrypt.genSaltSync(2))
        return HashedPassword
    }
    compareHash(Fetchedhash,Password){
        const doesPasswordMatch = bcrypt.compareSync(Password,Fetchedhash)
        return doesPasswordMatch
    }

}

export default new HashingService()