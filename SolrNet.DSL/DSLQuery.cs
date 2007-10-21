namespace SolrNet.DSL {
	public class DSLQuery<T> : DSLRun<T>, IDSLQuery<T> where T : ISolrDocument, new() {
		public DSLQuery(ISolrConnection connection) : base(connection) {}

		public DSLQuery(ISolrConnection connection, ISolrQuery<T> query) : base(connection, query) {}

		public IDSLQueryRange<T> ByRange<RT>(string fieldName, RT from, RT to) {
			return new DSLQueryRange<T, RT>(connection, query, fieldName, from, to);
		}

		public IDSLQueryBy<T> By(string fieldName) {
			return new DSLQueryBy<T>(fieldName, connection, query);
		}

		public IDSLQuery<T> ByExample(T doc) {
			return new DSLQuery<T>(connection,
			                       new SolrMultipleCriteriaQuery<T>(new ISolrQuery<T>[] {
			                                                                            	query,
			                                                                            	new SolrQueryByExample<T>(doc)
			                                                                            }));
		}
	}
}