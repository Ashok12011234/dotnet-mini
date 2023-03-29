package main

import (
	"log"
	"net/http"
 )


func main()  {

	 //handle /hello route
	 http.HandleFunc("/authorized",handlePage )

	 //listen to the port in 8080
	 err :=http.ListenAndServe(":8070",nil)

	 if err != nil {
	 	log.Println("There was an error listening on port :8080", err)
	  }
	 
	

}



func handlePage(writer http.ResponseWriter, request *http.Request) {
	//log.Println("Called :")
	//if(request.Header["accessToken"] != nil &&  request.Header["accessToken"]!=""){
		writer.Write([]byte("Platinum"))
		//log.Println("Called :")
		//writer.Write([]byte(request.Header["accessToken"][0]))
	///}
    
}