import React, { Component } from 'react';
import { connect } from 'react-redux'
import DateRangePicker from '@wojtekmaj/react-daterange-picker';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "../fontawesomeLibrary";
import moment from "moment";
import { getUserAction } from '../redux/actions/userActions'

export class FetchData extends Component {
    static displayName = FetchData.name;
    state = {
        date: [new Date(), new Date()],
      }

    componentDidMount() {
        this.props.getUserAction();

    }

    handleDate = date => {
        this.setState({ date })
       this.state.date.map(console.log)

    }
    render() {
        console.log(this.state.date)

        const { users } = this.props
        return (
            <div>
                <h1>Weather forecast</h1>
                <DateRangePicker onChange= {this.handleDate} value={this.state.date} maxDate={new Date()}  />
               
                <p>This component demonstrates fetching data from the server using Redux.</p>
                {users && users.map((post, i) => <div key={i}>
                    {post.data.first_Name}--{post.data.last_Name}
                    <img alt="avatar" src={post.data.avatar} />
                </div>)}
            </div>
        );
    }
}

//what is passed to the component via props
const mapStateToProps = (state) => {
    return {
        users: state.users
    };
}

export default connect(mapStateToProps, { getUserAction })(FetchData);
