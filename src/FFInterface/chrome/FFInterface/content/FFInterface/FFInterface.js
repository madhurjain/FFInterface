var serv;
var prefs = Components.classes["@mozilla.org/preferences-service;1"]
                    .getService(Components.interfaces.nsIPrefBranch);
		    
window.addEventListener("load", function(e) { if(prefs.getBoolPref("extensions.FFInterface.autoStart")) Start(); }, false);
window.addEventListener("unload", function(e) { stop(); }, false);

var listener = {
onSocketAccepted : function(socket, transport){
try {
	var outstream = transport.openOutputStream(Components.interfaces.nsITransport.OPEN_BLOCKING , 0, 0);
	var stream = transport.openInputStream(0, 0, 0);
	var instream = Components.classes['@mozilla.org/intl/converter-input-stream;1'].createInstance(Components.interfaces.nsIConverterInputStream);
	instream.init(stream, 'UTF-8', 1024, Components.interfaces.nsIConverterInputStream.DEFAULT_REPLACEMENT_CHARACTER);
	var pump = Components.classes['@mozilla.org/network/input-stream-pump;1'].createInstance(Components.interfaces.nsIInputStreamPump);
	pump.init(stream, -1, -1, 0, 0, false);
	pump.asyncRead({
	onStartRequest: function(request, context) {},
	onStopRequest: function(request, context, status) {
	instream.close();
	outstream.close();},
	onDataAvailable: function(request, context, inputStream, offset, count) {
	var str = {}
	instream.readString(count, str)
	str.value = removeNL(str.value);
	log(escape(str.value));
	//alert(str.value.split('|'));
	var t = new Array();
	t=str.value.split('|');
	if(t[0] == 's')
	{
		var u = 'javascript:var a=' + t[1];
		gBrowser.loadURI(u);
		log(a);
		outputString = "1";
		outstream.write(outputString,outputString.length);
	}
	else if(t[0] == 'gi')
	{
		if(window.content.document.getElementById(t[1]))
		{
			if(t[2] == 'checked'){
				var a = window.content.document.getElementById(t[1]).checked;			
			}
			else{
				var a = window.content.document.getElementById(t[1]).value;
				if(!a)
				   a="<blank>";
			}
			}
		else{
			a="<NULL>";
		}
		outputString = a.toString();
		outstream.write(outputString,outputString.length);
	}
	else if(t[0] == 'gn')
	{
		if(window.content.document.getElementsByName(t[1])[0])
		{
			if(t[2] == 'checked'){
				var a = window.content.document.getElementsByName(t[1])[0].checked;
			}
			else{
				var a = window.content.document.getElementsByName(t[1])[0].value;
				if(!a)
				   a="<blank>";
			}
		}
		else{
			a="<NULL>";
		}
		outputString = a.toString();
		outstream.write(outputString,outputString.length);
	}
	else
	{
		gBrowser.loadURI(str.value);
		log(a);
		outputString = "1";
		outstream.write(outputString,outputString.length);
	}
	}
        }, null);
    } catch(e) {
     	log('FFInterface: Error: ' + e);
    }
    	log('FFInterface: Accepted connection.');
},
onStopListening: function(serv, status) {
log('FFInterface: Stopped Listening');
}

};

function removeNL(s){ 
  return s.replace(/[\n\r\t]/g,""); 
}

function Start() {
    try {
        serv = Components.classes['@mozilla.org/network/server-socket;1'].createInstance(Components.interfaces.nsIServerSocket);
	var sPort = prefs.getIntPref("extensions.FFInterface.port");
	serv.init(sPort, false, -1);
        serv.asyncListen(listener);
	document.getElementById('FFInterface-command-toggle').setAttribute('label',"Stop FFInterface");
	log('FFInterface: Listening at port ' + sPort);
    } catch(e) {
        log('FFInterface: Exception: ' + e);
    }
}

function stop() {
	if(serv){
	serv.close();
	serv = undefined;
	document.getElementById('FFInterface-command-toggle').setAttribute('label',"Start FFInterface");
	}
}

function toggleServer(sourceCommand) {
    if(serv) {
	stop();
        sourceCommand.setAttribute('label', 'Start FFInterface');
    }
    else {
	Start();
        sourceCommand.setAttribute('label', 'Stop FFInterface');
    }
}

function updateMenu(){
//var sPort = prefs.getIntPref("extensions.FFInterface.port");
//log('Port = ' + sPort);
var aStart = prefs.getBoolPref("extensions.FFInterface.autoStart");
//log('autoStart = ' + aStart);
document.getElementById('FFInterface-command-autostart').setAttribute('checked', prefs.getBoolPref("extensions.FFInterface.autoStart"));
}

function togglePref(prefName)
{
	prefName = "extensions.FFInterface." + prefName;
	prefs.setBoolPref(prefName, !prefs.getBoolPref(prefName));
}

function changePort()
{
var pValue = window.prompt('Choose listening port', prefs.getIntPref("extensions.FFInterface.port"));
if(pValue)
    prefs.setIntPref("extensions.FFInterface.port", pValue);
    stop();
    Start();
}


function log(msg) {
    dump(msg + '\n');
}