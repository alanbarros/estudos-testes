const Dev = require('../models/Dev');

module.exports = {
    async store(req, res){

        const { user } = req.headers;
        const { devId } = req.params;

        const loggedDev = await Dev.findById(user);
        const targetDev = await Dev.findById(devId);

        if(!targetDev){
            return res.status(400).json({ message : "Dev not exists"});
        }

        if(targetDev.likes.includes(loggedDev._id)){
            console.log('DEU MATH')
        }

        loggedDev.likes.push(targetDev._id);

        await loggedDev.save();

        return res.json(loggedDev);

        return res.json({ok:true});
    }
}