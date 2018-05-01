class @Persister
    constructor: (@rootURL, @http, @encode) ->
        @sessionKey = localStorage.sessionKey if localStorage.sessionKey?
        @nickname = localStorage.nickname if localStorage.nickname?

    # USER
    login: (data) ->
        url = @rootURL + 'user/login/'
        data = _.clone data
        data.authCode = @encode(data.username + data.password)
        delete data.password

        @http.postJSON(url, data).done (data) =>
            @sessionKey = data.sessionKey
            @nickname = data.nickname

            localStorage.sessionKey = data.sessionKey
            localStorage.nickname = data.nickname

    register: (data) ->
        url = @rootURL + 'user/register/'
        data = _.clone data
        data.authCode = @encode(data.username + data.password)
        delete data.password

        @http.postJSON url, data

    logout: ->
        url = @rootURL + 'user/logout/' + @sessionKey

        @http.getJSON(url).done =>
            delete @sessionKey
            delete localStorage.sessionKey

            delete @nickname
            delete localStorage.nickname

    scores: ->
        url = @rootURL + 'user/scores/' + @sessionKey

        @http.getJSON url

    isLoggedIn: ->
        @sessionKey?

    getNickname: ->
        @nickname

    # GAME
    createGame: (data) ->
        url = @rootURL + 'game/create/' + @sessionKey
        data = _.clone data

        if data.password? and data.password != ''
            data.password = @encode data.password
        else
            delete data.password

        @http.postJSON url, data

    joinGame: (data) ->
        url = @rootURL + 'game/join/' + @sessionKey
        data = _.clone data

        if data.password? and data.password != ''
            data.password = @encode data.password
        else
            delete data.password

        @http.postJSON url, data

    startGame: (id) ->
        url = @rootURL + 'game/' + id  + '/start/' + @sessionKey

        @http.getJSON url

    getGameField: (id) ->
        url = @rootURL + 'game/' + id + '/field/' + @sessionKey

        @http.getJSON url

    getOpenGames: ->
        url = @rootURL + 'game/open/' + @sessionKey

        @http.getJSON url

    getMyActiveGames: ->
        url = @rootURL + 'game/my-active/' + @sessionKey

        @http.getJSON url

    getMyColor: (id, success, fail) ->
        nickname = this.getNickname()

        this.getMyActiveGames().done (games) ->
            creator = games.filter((game) -> game.id is id)[0].creator
            color = if creator is nickname then 'red' else 'blue'
            # console.log nickname, creator, color
            success(color)

    # BATTLE

    # TODO
    battleMove: (data, id) ->
        url = @rootURL + 'battle/' + id + '/move/' + @sessionKey

        @http.postJSON url, data

    battleAttack: (data, id) ->
        url = @rootURL + 'battle/' + id + '/attack/' + @sessionKey

        @http.postJSON url, data

    battleDefend: (data, id) ->
        url = @rootURL + 'battle/' + id + '/defend/' + @sessionKey

        @http.postJSON url, data # ID Only

    # MESSAGES
    getUnreadMessages: ->
        url = @rootURL + 'messages/unread/' + @sessionKey

        @http.getJSON url

    getAllMessages: ->
        url = @rootURL + 'messages/all/' + @sessionKey

        @http.getJSON url


