import Action from './actions'
import { UserFilter } from '@/entities/user-filter'
import { User } from '@/entities/user'
import client from "@/api-client"

var Mutations = {
  setUsers: "setUsers",
  setUserReceiving: "setUserReceiving",
  setUserSending: "setUserSending"
}

const UserModule ={
  state: { 
    userFilter: new UserFilter(),
    users : new Array<User>(),

    userDataReceiving: false,
    userDataSending: false,
  },
  mutations: { 
    [Mutations.setUsers](state: any, users: Array<User>){
     state.users = users
    },
    [Mutations.setUserReceiving](state: any, value: boolean){
     state.userDataReceiving = value
    },
    [Mutations.setUserSending](state: any, value: boolean){
     state.userDataSending = value
    }
   },
  actions: {  
    async [Action.UserList]({commit, state}){
      commit(Mutations.setUserSending, true)
      try{
        const r = await client.user.getUserList(state.userFilter)
        commit(Mutations.setUsers, r.data)
        commit(Mutations.setUserSending, false)
      }
      catch(e){
        commit(Mutations.setUserSending, false)
      }
    }
  },
  getters: {
    users: state => state.users,
    userFilter: state => state.userFilter,
  }
}

export default UserModule