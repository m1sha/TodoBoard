import { User } from './user'

export class TodoItem {
  uid: string
  title: string
  message: string
  status: number
  type: number
  userCreator: User
  userAssign: User

  constructor(){
    this.uid = ""
    this.title = ""
    this.message = ""
    this.status = 0
    this.type = 0
    this.userCreator = new User()
    this.userAssign =  new User()
  }
}