﻿/* =============================================================
 * bootstrap-typeahead.js v2.3.2
 * http://twbs.github.com/bootstrap/javascript.html#typeahead
 * =============================================================
 * Copyright 2013 Twitter, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ============================================================ */


!function ($) {

    "use strict"; // jshint ;_;


    /* TYPEAHEAD PUBLIC CLASS DEFINITION
     * ================================= */

    var Typeahead = function (element, options) {
        this.$element = $(element)
        this.options = $.extend({}, $.fn.typeahead.defaults, options)
        this.matcher = this.options.matcher || this.matcher
        this.sorter = this.options.sorter || this.sorter
        this.highlighter = this.options.highlighter || this.highlighter
        this.updater = this.options.updater || this.updater
        this.source = this.options.source
        //this.$container = $(this.options.container)
        this.$menu = $(this.options.menu)
        //this.$pager = $(this.options.pager)
        this.shown = false
        this.listen()
    }

    Typeahead.prototype = {

        constructor: Typeahead

    , select: function () {
        var val = this.$menu.find('.active').attr('data-value')
        //var val = this.$container.find('.active').attr('data-value')
        this.$element
          .val(this.updater(val))
          .change()
        return this.hide()
    }

    , updater: function (item) {
        return item
    }

    , show: function () {
        var pos = $.extend({}, this.$element.position(), {
            height: this.$element[0].offsetHeight
        })

        var width = this.$element.width() + 26;

        this.$menu
          .insertAfter(this.$element)
          .css({
              top: pos.top + pos.height
          , left: pos.left
              , width: width
          })
          .show()

  //this.$container.insertAfter(this.$element)
  //.css({
  //    top: pos.top + pos.height
  //, left: pos.left
  //    , width: width
  //})
  //.show()

  //      this.$menu.css({
  //          top: pos.top + pos.height
  //, left: pos.left
  //    , width: width
  //     , position: 'inherit'
  //      })
  //.show()

        this.shown = true
        return this
    }

    , hide: function () {
        this.$menu.hide()
        //this.$container.hide()
        this.shown = false
        return this
    }

    , lookup: function (event) {
        var items

        this.query = this.$element.val()

        if (!this.query || this.query.length < this.options.minLength) {
            return this.shown ? this.hide() : this
        }

        items = $.isFunction(this.source) ? this.source(this.query, $.proxy(this.process, this), this.paging) : this.source

        return items ? this.process(items, this.paging) : this
    }

    , process: function (items, paging) {
        //sen viet : gán lại phân trang
        this.paging.totalrows = paging.TotalRows;
        this.paging.pagecount = paging.PageCount;
        this.paging.pagecurrent = paging.PageCurrent;
        //end sen viet

        var that = this

        items = $.grep(items, function (item) {
            return that.matcher(item)
        })

        items = this.sorter(items)

        //alert(items.length);
        if (!items.length) {
            return this.shown ? this.hide() : this
        }

        return this.render(items.slice(0, this.options.items)).show()
    }

    , matcher: function (item) {
        return ~item.toLowerCase().indexOf(this.query.toLowerCase())
    }

    , sorter: function (items) {
        var beginswith = []
          , caseSensitive = []
          , caseInsensitive = []
          , item

        while (item = items.shift()) {
            if (!item.toLowerCase().indexOf(this.query.toLowerCase())) beginswith.push(item)
            else if (~item.indexOf(this.query)) caseSensitive.push(item)
            else caseInsensitive.push(item)
        }

        return beginswith.concat(caseSensitive, caseInsensitive)
    }

    , highlighter: function (item) {
        var query = this.query.replace(/[\-\[\]{}()*+?.,\\\^$|#\s]/g, '\\$&')
        return item.replace(new RegExp('(' + query + ')', 'ig'), function ($1, match) {
            return '<strong>' + match + '</strong>'
        })
    }

    , render: function (items) {
        var that = this

        items = $(items).map(function (i, item) {
            i = $(that.options.item).attr('data-value', item)
            i.find('a').html(that.highlighter(item))
            return i[0]
        })

        items.first().addClass('active')
        this.$menu.html(items)

        ////senviet
        //var paging = this.paging;
        //var itempage = '';

        //itempage += "<li> " + paging.pagecurrent + " </li>";
        //itempage += "<li> / </li>";
        //itempage += "<li> " + paging.pagecount + " </li>";
        //itempage += "<li> ( " + paging.totalrows + " ) </li>";
        //itempage += "<li> <a class='pageprev' href='javascript:;'>Trước</a> </li>";
        //itempage += "<li> <a class='pagenext' href='javascript:;'>Sau</a> </li>";

        ////this.$pager.html(itempage);
        //this.$container.html(this.$menu);
        //this.$pager.insertAfter(this.$menu);
        ////endsenviet

        return this
    }
    //, test: function (event)
    //{
    //    alert("test");
    //}
    , pagenext: function (event) {

        if (this.paging.pagecurrent < this.paging.pagecount) {
            //di chuyển về trang sau đó
            this.paging.pagecurrent++;
            this.lookup();
        }

        //var active = this.$menu.find('.active').removeClass('active')
        //  , next = active.next()

        //if (!next.length) {
        //    next = $(this.$menu.find('li')[0])
        //}

        //next.addClass('active')
    }

    , pageprev: function (event) {
        if (this.paging.pagecurrent >= 2) {
            //di chuyển về trang trước đó
            this.paging.pagecurrent--;
            this.lookup();
        }
        //var active = this.$menu.find('.active').removeClass('active')
        //  , prev = active.prev()

        //if (!prev.length) {
        //    prev = this.$menu.find('li').last()
        //}
        //prev.addClass('active')
    }

    , next: function (event) {
        var active = this.$menu.find('.active').removeClass('active')
          , next = active.next()

        if (!next.length) {
            next = $(this.$menu.find('li')[0])
        }

        next.addClass('active')
    }

    , prev: function (event) {
        var active = this.$menu.find('.active').removeClass('active')
          , prev = active.prev()

        if (!prev.length) {
            prev = this.$menu.find('li').last()
        }

        prev.addClass('active')
    }

    , listen: function () {
        this.$element
          .on('focus', $.proxy(this.focus, this))
          .on('blur', $.proxy(this.blur, this))
          .on('keypress', $.proxy(this.keypress, this))
          .on('keyup', $.proxy(this.keyup, this))

        if (this.eventSupported('keydown')) {
            this.$element.on('keydown', $.proxy(this.keydown, this))
        }

        this.$menu
          .on('click', $.proxy(this.click, this))
          .on('mouseenter', 'li', $.proxy(this.mouseenter, this))
          .on('mouseleave', 'li', $.proxy(this.mouseleave, this))

        //this.$pager.on('click', $.proxy(this.test, this))
        //this.$pager.on('click', 'a', $.proxy(this.test, this))
        //this.$pager('.pagenext').on('click', $.proxy(this.test, this))
    }

    , eventSupported: function (eventName) {
        var isSupported = eventName in this.$element
        if (!isSupported) {
            this.$element.setAttribute(eventName, 'return;')
            isSupported = typeof this.$element[eventName] === 'function'
        }
        return isSupported
    }

    , move: function (e) {
        if (!this.shown) return

        switch (e.keyCode) {
            case 9: // tab
            case 13: // enter
            case 27: // escape
                e.preventDefault()
                break
            case 33: // page up
                e.preventDefault()
                this.pageprev()
                break
            case 34: // page down
                e.preventDefault()
                this.pagenext()
                break
            case 38: // up arrow
                e.preventDefault()
                this.prev()
                break

            case 40: // down arrow
                e.preventDefault()
                this.next()
                break
        }

        e.stopPropagation()
    }

    , keydown: function (e) {
        this.suppressKeyPressRepeat = ~$.inArray(e.keyCode, [40, 38, 9, 13, 27])
        this.move(e)
    }

    , keypress: function (e) {
        if (this.suppressKeyPressRepeat) return
        this.move(e)
    }

    , keyup: function (e) {
        switch (e.keyCode) {
            case 40: // down arrow
            case 38: // up arrow
            case 16: // shift
            case 17: // ctrl
            case 18: // alt
                break

            case 9: // tab
            case 13: // enter
                if (!this.shown) return
                this.select()
                break

            case 27: // escape
                if (!this.shown) return
                this.hide()
                break

            default:
                this.lookup()
        }

        e.stopPropagation()
        e.preventDefault()
    }

    , focus: function (e) {
        this.focused = true
    }

    , blur: function (e) {
        this.focused = false
        if (!this.mousedover && this.shown) this.hide()
    }

    , click: function (e) {
        e.stopPropagation()
        e.preventDefault()
        this.select()
        this.$element.focus()
    }

    , mouseenter: function (e) {
        this.mousedover = true
        this.$menu.find('.active').removeClass('active')
        $(e.currentTarget).addClass('active')
    }

    , mouseleave: function (e) {
        this.mousedover = false
        if (!this.focused && this.shown) this.hide()
    }
    , paging:
        {
            totalrows: 0,
            pagesize: 10,
            pagecount: 1,
            pagecurrent: 1
        }
    }


    /* TYPEAHEAD PLUGIN DEFINITION
     * =========================== */

    var old = $.fn.typeahead

    $.fn.typeahead = function (option) {
        return this.each(function () {
            var $this = $(this)
              , data = $this.data('typeahead')
              , options = typeof option == 'object' && option
            if (!data) $this.data('typeahead', (data = new Typeahead(this, options)))
            if (typeof option == 'string') data[option]()
        })
    }

    $.fn.typeahead.defaults = {
        source: []
    , items: 8
    //, container: '<div class="typeahead-container"></div>'
    , menu: '<ul class="typeahead dropdown-menu"></ul>'
    , item: '<li><a href="#"></a></li>'
    , minLength: 1
    //, pager: '<a href="javascript:;">Trước</a>'
    }

    $.fn.typeahead.Constructor = Typeahead


    /* TYPEAHEAD NO CONFLICT
     * =================== */

    $.fn.typeahead.noConflict = function () {
        $.fn.typeahead = old
        return this
    }


    /* TYPEAHEAD DATA-API
     * ================== */

    $(document).on('focus.typeahead.data-api', '[data-provide="typeahead"]', function (e) {
        var $this = $(this)
        if ($this.data('typeahead')) return
        $this.typeahead($this.data())
    })

}(window.jQuery);
