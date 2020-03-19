import * as signalR from "@microsoft/signalr"

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/crudSyncHub")
    .build();


connection.start().catch(err => console.log(err));

export default class TodoListBroadcast{

  constructor(storage: any){
    connection.on("TodoListReceived", data => {
      storage.dispatch("TodoList");
    });
  }

  send(data: any){
    connection.send("TodoListSending", data)
  }

}