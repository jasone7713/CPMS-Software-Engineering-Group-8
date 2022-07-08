//require discord.js
const Discord = require('discord.js');

//create the bot instance
const bot = new Discord.Client({
    intents: [ Discord.Intents.FLAGS.GUILDS, Discord.Intents.FLAGS.GUILD_MESSAGES ]
});

//character prefic for starting a command
const prefix = '$';

bot.once('ready', () => {
    console.log('I\'m online, bruv');
})

bot.on('message', message => {
    //check if the message started with the prefix
    if(!message.content.startsWith(prefix) || message.author.bot) return;

    //splice the command from the message
    const args = message.content.slice(prefix.length).split(/ +/);

    const command = args.shift().toLowerCase();

    if(command === 'ping'){
        message.channel.send('pong!');
    }else if(command === 'shutdown'){
        message.channel.send('Bye..');
        bot.destroy();
    }
});




//log into the bot
bot.login('OTU1OTcyMzI1MjczMTMzMDU3.Yjpcmw.oeB6zaegJQVW--5SK4X0Ug0VE7A');