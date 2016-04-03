//React component that takes in some text as a property and displays it
var Tweet = React.createClass({
	render: function() {
		return <div className="xui-contentblock--item"> {this.props.text} </div>
	}
});

var Button = React.createClass({
	render: function() {
		return <button className="xui-button xui-u-flex-col" onClick={this.props.link}> {this.props.label} </button>
	}
});

//React component that makes a call to the API in the HomeController. If more than one tweet is returned, it displays a Tweet component for each.
var TweetContainer = React.createClass({
	//React function that sets the initial state of the app (where changeable data is stored)
	getInitialState: function() {
		return {tweets: []};
	},

	//React function that runs after the app first loads
	componentDidMount: function() {
		var self = this;
		fetch('/home/data', {method: 'post'})
			.then(function(response) {
				return response.json();
			})
			.then(function(data) {
				self.setState({tweets: data});
			})
			.catch(function(error) {
				console.error('Error', error);
			});
	},

	save: function() {
		console.log('saved!');
	},

	loadMore: function() {
		console.log('loading!');
	},

	//React function that runs on first load and whenever the state is changed
	render: function() {

		var tweets = (this.state.tweets.length > 0) ? this.state.tweets.map(function(tweet) {
			return <Tweet key={tweet.Id} text={tweet.Text} />
			})
			: null;

		return (
			<div className="xui-pagecontainer xui-pagecontainer-small">
				<h2 className="xui-heading">Welcome to the Xeromatic!</h2>
				<div className="xui-u-flex">
					<Button label="Save" link={this.save} />
					<Button label="Load More" link={this.loadMore} />
				</div>
				<div className="xui-panel">{tweets}</div>
			</div>
		);

	}
});

//This function will render our TweetContainer to the page
ReactDOM.render(<TweetContainer />, document.getElementById('app'));