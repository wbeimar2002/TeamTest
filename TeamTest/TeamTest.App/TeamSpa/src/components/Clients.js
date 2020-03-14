import axios from 'axios'
import React, {Component} from 'react';
import * as commonConstants from '../common/constants'
import {Table} from 'react-bootstrap';
class Clients extends Component{
    state = {
        clients: []
    }

    componentDidMount(){
        const uri = commonConstants.baseApiUrl+commonConstants.clientResource;
        axios.get(uri)
            .then(res => {
            const clients = res.data;
            this.setState({ clients });
        }).catch(error => {
            throw error;
            });
    }

    render(){
        return(
            <div>
                <h1>Clients</h1>
                <br></br>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                        <th>Client Id</th>
                        <th>Client Name</th>
                        <th>Gender</th>
                        <th>Identification</th>
                        <th>Phone Number</th>
                        <th>Email</th>
                        </tr>
                    </thead>
                    <tbody>
                        { this.state.clients.map(client => 
                            <tr key={client.id}>
                                <td>{client.id}</td>
                                <td>{client.name}</td>
                                <td>{client.gender}</td>
                                <td>{client.identificationNumber}</td>
                                <td>{client.phoneNumber}</td>
                                <td>{client.email}</td>
                            </tr>)
                        }
                    </tbody>
                </Table>
            </div>
        )

    }
}

export default Clients;