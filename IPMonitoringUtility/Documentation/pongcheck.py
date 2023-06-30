from datetime import datetime
import pyodbc 
import requests 
# Some other example server values are
# server = 'localhost\sqlexpress' # for a named instance
# server = 'myserver,port' # to specify an alternate port
server = 'tcp:10.77.76.95' 
database = 'pong' 
username = 'pong' 
password = 'Baofeng20!' 
cnxn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER='+server+';DATABASE='+database+';UID='+username+';PWD='+ password)
cursor = cnxn.cursor()
#Sample select query
cursor.execute("EXEC procListStatusInactivo;") 
row = cursor.fetchone() 
cadena = ""
ahora = datetime.now()
hora = ahora.strftime("%H:%M:%S | %D")
camaras = 0
while row: 
	if row[3] != 'Camaras IP':
		cadena = cadena + row[0] + " | " + row[1] + " | " + row[3] + "\r\n"
	else:
		camaras+=1
	row = cursor.fetchone()
cadena = hora + "\r\n" + cadena + "Camaras Inactivas: " + str(camaras)
print(cadena)
urlbot = "https://api.telegram.org/bot1193005029:AAFFdghEBI8WHTVFor-jt27p0-x7Ok0u94Q/sendMessage?chat_id=1183019388&text=" + cadena
enviarabot = requests.get(url = urlbot) 